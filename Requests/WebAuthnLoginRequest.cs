using System.Text.Json;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for WebAuthn login.
/// </summary>
public sealed class WebAuthnLoginRequest
{
    /// <summary>
    /// Auth response payload provided by the browser WebAuthn API.
    /// </summary>
    public JsonElement Auth { get; set; }

    /// <summary>
    /// Optional session cookie preference.
    /// </summary>
    public bool? UseSessionCookie { get; set; }
}
