namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for health checks.
/// </summary>
public sealed class HealthcheckResponse
{
    /// <summary>
    /// Status string.
    /// </summary>
    public string? Status { get; set; }
}
