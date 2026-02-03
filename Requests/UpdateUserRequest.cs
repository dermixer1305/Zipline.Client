namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for updating a user.
/// </summary>
public sealed class UpdateUserRequest
{
    /// <summary>
    /// Optional new username.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Optional new password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Optional role.
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// Optional quota settings.
    /// </summary>
    public UserQuotaRequest? Quota { get; set; }
}
