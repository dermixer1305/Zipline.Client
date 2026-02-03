using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Internal;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

internal sealed class AuthApi : IAuthApi
{
    private readonly ZiplineClient _client;

    public AuthApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<AuthResponse> LoginAsync(AuthLoginRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<AuthResponse>(HttpMethod.Post, "api/auth/login", request, cancellationToken);

    public Task<AuthResponse> RegisterAsync(AuthRegisterRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<AuthResponse>(HttpMethod.Post, "api/auth/register", request, cancellationToken);

    public Task<SimpleStatusResponse> LogoutAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<SimpleStatusResponse>("api/auth/logout", cancellationToken);

    public Task<Invite[]> ListInvitesAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<Invite[]>("api/auth/invites", cancellationToken);

    public Task<Invite> CreateInviteAsync(CreateInviteRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Invite>(HttpMethod.Post, "api/auth/invites", request, cancellationToken);

    public Task<Invite> GetInviteAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<Invite>($"api/auth/invites/{id}", cancellationToken);

    public Task<Invite> DeleteInviteAsync(string id, CancellationToken cancellationToken = default)
        => _client.DeleteAsync<Invite>($"api/auth/invites/{id}", cancellationToken);

    public Task<AuthResponse> WebAuthnLoginAsync(WebAuthnLoginRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<AuthResponse>(HttpMethod.Post, "api/auth/webauthn", request, cancellationToken);
}
