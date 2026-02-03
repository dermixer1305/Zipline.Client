using Zipline.Client.Models;

namespace Zipline.Client.Responses;

/// <summary>
/// Authentication response payload.
/// </summary>
public sealed class AuthResponse
{
    /// <summary>
    /// Authenticated user.
    /// </summary>
    public User User { get; set; } = new();
}
