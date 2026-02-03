namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for TOTP setup.
/// </summary>
public sealed class TotpSetupResponse
{
    /// <summary>
    /// Secret used to configure an authenticator.
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// Data URL for QR code.
    /// </summary>
    public string? DataUrl { get; set; }
}
