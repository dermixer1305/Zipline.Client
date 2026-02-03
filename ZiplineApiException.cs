using System;
using System.Net;
using System.Net.Http.Headers;
using Zipline.Client.Responses;

namespace Zipline.Client;

/// <summary>
/// Exception thrown when the Zipline API returns a non-success response.
/// </summary>
public sealed class ZiplineApiException : Exception
{
    public ZiplineApiException(HttpStatusCode statusCode, ErrorResponse? error, string? responseBody, HttpResponseHeaders headers)
        : base(BuildMessage(statusCode, error))
    {
        StatusCode = statusCode;
        Error = error;
        ResponseBody = responseBody;
        Headers = headers;
    }

    /// <summary>
    /// HTTP status code returned by the API.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Parsed error response, if available.
    /// </summary>
    public ErrorResponse? Error { get; }

    /// <summary>
    /// Raw response body, if available.
    /// </summary>
    public string? ResponseBody { get; }

    /// <summary>
    /// Response headers returned by the API.
    /// </summary>
    public HttpResponseHeaders Headers { get; }

    private static string BuildMessage(HttpStatusCode statusCode, ErrorResponse? error)
    {
        if (error is null)
        {
            return $"Zipline API request failed with status {(int)statusCode} ({statusCode}).";
        }

        return $"Zipline API request failed with status {(int)statusCode} ({statusCode}): {error.Error}.";
    }
}
