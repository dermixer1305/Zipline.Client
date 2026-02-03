namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for first-time setup.
/// </summary>
public sealed class SetupRequest
{
    /// <summary>
    /// Admin username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Admin password.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
