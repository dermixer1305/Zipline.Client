using Zipline.Client.Models;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for setup.
/// </summary>
public sealed class SetupResponse
{
    /// <summary>
    /// Created admin user.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Optional token returned by the server.
    /// </summary>
    public string? Token { get; set; }
}
