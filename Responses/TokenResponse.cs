namespace Zipline.Client.Responses;

/// <summary>
/// Token response payload.
/// </summary>
public sealed class TokenResponse
{
    /// <summary>
    /// API token.
    /// </summary>
    public string Token { get; set; } = string.Empty;
}
