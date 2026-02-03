namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for password checks.
/// </summary>
public sealed class PasswordCheckResponse
{
    /// <summary>
    /// Whether the password is valid.
    /// </summary>
    public bool Success { get; set; }
}
