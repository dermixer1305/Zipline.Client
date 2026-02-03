namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for creating a user.
/// </summary>
public sealed class CreateUserRequest
{
    /// <summary>
    /// Username for the new user.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Password for the new user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// User role (USER, ADMIN).
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// Optional quota settings.
    /// </summary>
    public UserQuotaRequest? Quota { get; set; }
}
