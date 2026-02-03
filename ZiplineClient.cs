using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Api;
using Zipline.Client.Internal;
using Zipline.Client.Responses;

namespace Zipline.Client;

/// <summary>
/// Default Zipline API client implementation.
/// </summary>
public sealed class ZiplineClient : IZiplineClient
{
    private readonly HttpClient _httpClient;
    private readonly ZiplineOptions _options;
    private readonly JsonSerializerOptions _jsonOptions;
    private bool _disposed;

    /// <summary>
    /// Creates a client with a new HttpClient instance.
    /// </summary>
    public ZiplineClient(ZiplineOptions options)
        : this(new HttpClient(), options)
    {
        _options.DisposeHttpClient = true;
    }

    /// <summary>
    /// Creates a client with a provided HttpClient instance.
    /// </summary>
    public ZiplineClient(HttpClient httpClient, ZiplineOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _options.ApplyTo(_httpClient);
        _jsonOptions = ZiplineJson.CreateOptions();

        Auth = new AuthApi(this);
        User = new UserApi(this);
        Users = new UsersApi(this);
        Server = new ServerApi(this);
        Upload = new UploadApi(this);
        Misc = new MiscApi(this);
    }

    /// <inheritdoc />
    public IAuthApi Auth { get; }

    /// <inheritdoc />
    public IUserApi User { get; }

    /// <inheritdoc />
    public IUsersApi Users { get; }

    /// <inheritdoc />
    public IServerApi Server { get; }

    /// <inheritdoc />
    public IUploadApi Upload { get; }

    /// <inheritdoc />
    public IMiscApi Misc { get; }

    internal JsonSerializerOptions JsonOptions => _jsonOptions;

    internal Uri BuildUri(string path)
    {
        var baseUri = _options.BaseUri;
        if (!baseUri.AbsoluteUri.EndsWith("/", StringComparison.Ordinal))
        {
            baseUri = new Uri(baseUri.AbsoluteUri + "/");
        }

        return new Uri(baseUri, path.TrimStart('/'));
    }

    internal HttpRequestMessage CreateRequest(HttpMethod method, string path, HttpContent? content, IDictionary<string, string?>? headers)
    {
        var request = new HttpRequestMessage(method, BuildUri(path));

        if (!string.IsNullOrWhiteSpace(_options.AuthToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.AuthToken);
        }

        if (!string.IsNullOrWhiteSpace(_options.SessionCookie))
        {
            request.Headers.Add("Cookie", $"user={_options.SessionCookie}");
        }

        if (headers is not null)
        {
            foreach (var (key, value) in headers)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    request.Headers.TryAddWithoutValidation(key, value);
                }
            }
        }

        if (content is not null)
        {
            request.Content = content;
        }

        return request;
    }

    internal async Task<T> SendAsync<T>(HttpMethod method, string path, HttpContent? content, IDictionary<string, string?>? headers, CancellationToken cancellationToken)
    {
        using var request = CreateRequest(method, path, content, headers);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var responseBody = response.Content is null ? null : await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            ErrorResponse? error = null;

            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                try
                {
                    error = JsonSerializer.Deserialize<ErrorResponse>(responseBody, _jsonOptions);
                }
                catch
                {
                    error = null;
                }
            }

            response.Dispose();
            throw new ZiplineApiException(response.StatusCode, error, responseBody, response.Headers);
        }

        if (typeof(T) == typeof(HttpResponseMessage))
        {
            return (T)(object)response;
        }

        if (response.Content is null)
        {
            response.Dispose();
            return default!;
        }

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var payload = await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        response.Dispose();
        return payload!;
    }

    internal Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        => SendAsync<T>(HttpMethod.Get, path, null, null, cancellationToken);

    internal Task<T> DeleteAsync<T>(string path, CancellationToken cancellationToken = default)
        => SendAsync<T>(HttpMethod.Delete, path, null, null, cancellationToken);

    internal Task<T> SendJsonAsync<T>(HttpMethod method, string path, object? payload, CancellationToken cancellationToken = default)
    {
        HttpContent? content = null;
        if (payload is not null)
        {
            content = JsonContent.Create(payload, options: _jsonOptions);
        }

        return SendAsync<T>(method, path, content, null, cancellationToken);
    }

    internal Task<T> SendJsonAsync<T>(HttpMethod method, string path, object? payload, IDictionary<string, string?>? headers, CancellationToken cancellationToken = default)
    {
        HttpContent? content = null;
        if (payload is not null)
        {
            content = JsonContent.Create(payload, options: _jsonOptions);
        }

        return SendAsync<T>(method, path, content, headers, cancellationToken);
    }

    /// <inheritdoc />
    public Task<HttpResponseMessage> SendRawAsync(HttpMethod method, string path, HttpContent? content = null, IDictionary<string, string?>? headers = null, CancellationToken cancellationToken = default)
        => SendAsync<HttpResponseMessage>(method, path, content, headers, cancellationToken);

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        if (_options.DisposeHttpClient)
        {
            _httpClient.Dispose();
        }

        _disposed = true;
    }
}
