namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for registration.
/// </summary>
public sealed class AuthRegisterRequest
{
    /// <summary>
    /// Username for the account.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Password for the account.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Optional invite code.
    /// </summary>
    public string? Invite { get; set; }
}
