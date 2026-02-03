using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

/// <summary>
/// Authentication endpoints.
/// </summary>
public interface IAuthApi
{
    /// <summary>
    /// Authenticate a user with username and password.
    /// </summary>
    Task<AuthResponse> LoginAsync(AuthLoginRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Register a user.
    /// </summary>
    Task<AuthResponse> RegisterAsync(AuthRegisterRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Logout the current user.
    /// </summary>
    Task<SimpleStatusResponse> LogoutAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List invites.
    /// </summary>
    Task<Invite[]> ListInvitesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new invite.
    /// </summary>
    Task<Invite> CreateInviteAsync(CreateInviteRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a specific invite by id.
    /// </summary>
    Task<Invite> GetInviteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an invite by id.
    /// </summary>
    Task<Invite> DeleteInviteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Perform WebAuthn authentication.
    /// </summary>
    Task<AuthResponse> WebAuthnLoginAsync(WebAuthnLoginRequest request, CancellationToken cancellationToken = default);
}
