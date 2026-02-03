namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for password verification.
/// </summary>
public sealed class PasswordCheckRequest
{
    /// <summary>
    /// Password to verify.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
