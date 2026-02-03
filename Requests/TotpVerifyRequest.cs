namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for verifying a TOTP token.
/// </summary>
public sealed class TotpVerifyRequest
{
    /// <summary>
    /// TOTP token to verify.
    /// </summary>
    public string Token { get; set; } = string.Empty;
}
