using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

internal sealed class UploadApi : IUploadApi
{
    private readonly ZiplineClient _client;

    public UploadApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<UploadResponse> UploadAsync(IEnumerable<UploadFile> files, UploadOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (files is null)
        {
            throw new ArgumentNullException(nameof(files));
        }

        var form = new MultipartFormDataContent();

        if (options?.Fields is not null)
        {
            foreach (var (key, value) in options.Fields)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    form.Add(new StringContent(value!), key);
                }
            }
        }

        foreach (var file in files)
        {
            var content = new StreamContent(file.Content);
            if (!string.IsNullOrWhiteSpace(file.ContentType))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            }

            form.Add(content, "file", file.FileName);
        }

        Dictionary<string, string?>? headers = null;
        if (options?.Headers is not null && options.Headers.Count > 0)
        {
            headers = new Dictionary<string, string?>();
            foreach (var (key, value) in options.Headers)
            {
                headers[key] = value;
            }
        }

        return _client.SendAsync<UploadResponse>(HttpMethod.Post, "api/upload", form, headers, cancellationToken);
    }

    public async Task<UploadResponse> UploadBase64Async(string fileName, string base64, string? contentType = null, UploadOptions? options = null, CancellationToken cancellationToken = default)
    {
        var uploadFile = UploadFile.FromBase64(fileName, base64, contentType);
        using var _ = uploadFile.Content;
        return await UploadAsync(new[] { uploadFile }, options, cancellationToken).ConfigureAwait(false);
    }

    public Task<UploadResponse> UploadPartialAsync(HttpContent content, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string?>? headerDictionary = null;
        if (headers is not null && headers.Count > 0)
        {
            headerDictionary = new Dictionary<string, string?>();
            foreach (var (key, value) in headers)
            {
                headerDictionary[key] = value;
            }
        }

        return _client.SendAsync<UploadResponse>(HttpMethod.Post, "api/upload/partial", content, headerDictionary, cancellationToken);
    }
}
