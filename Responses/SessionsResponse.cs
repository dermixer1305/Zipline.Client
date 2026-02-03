namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for sessions.
/// </summary>
public sealed class SessionsResponse
{
    /// <summary>
    /// Current session id.
    /// </summary>
    public string? Current { get; set; }

    /// <summary>
    /// Other session ids.
    /// </summary>
    public string[]? Other { get; set; }
}
