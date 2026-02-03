using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Zipline.Client;

/// <summary>
/// Configuration for the Zipline API client.
/// </summary>
public sealed class ZiplineOptions
{
    /// <summary>
    /// Base URL of the Zipline instance (e.g. https://zipline.example.com).
    /// </summary>
    public Uri BaseUri { get; set; } = new("https://zipline.diced.sh");

    /// <summary>
    /// Optional API token used for Authorization headers.
    /// </summary>
    public string? AuthToken { get; set; }

    /// <summary>
    /// Optional session cookie value (the raw value of the "user" cookie).
    /// </summary>
    public string? SessionCookie { get; set; }

    /// <summary>
    /// Optional User-Agent header.
    /// </summary>
    public string? UserAgent { get; set; }

    /// <summary>
    /// Optional default request timeout.
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// Optional default headers applied to all requests.
    /// </summary>
    public Dictionary<string, string?> DefaultHeaders { get; } = new();

    /// <summary>
    /// If true, the client owns the HttpClient instance and will dispose it.
    /// </summary>
    internal bool DisposeHttpClient { get; set; }

    /// <summary>
    /// Applies options to an existing HttpClient instance.
    /// </summary>
    internal void ApplyTo(HttpClient httpClient)
    {
        if (Timeout.HasValue)
        {
            httpClient.Timeout = Timeout.Value;
        }

        if (!string.IsNullOrWhiteSpace(UserAgent))
        {
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        }

        foreach (var (key, value) in DefaultHeaders)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
            }
        }
    }
}
