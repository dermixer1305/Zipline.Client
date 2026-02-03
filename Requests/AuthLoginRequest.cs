namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for login.
/// </summary>
public sealed class AuthLoginRequest
{
    /// <summary>
    /// Username to authenticate.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Password to authenticate.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Whether to return a session cookie only.
    /// </summary>
    public bool? UseSessionCookie { get; set; }
}
