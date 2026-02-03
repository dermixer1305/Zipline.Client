using System.Text.Json.Serialization;

namespace Zipline.Client.Responses;

/// <summary>
/// Error payload returned by the API.
/// </summary>
public sealed class ErrorResponse
{
    /// <summary>
    /// Error message.
    /// </summary>
    public string Error { get; set; } = string.Empty;

    /// <summary>
    /// Error type (if provided).
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Optional error stack.
    /// </summary>
    public string? Stack { get; set; }
}
