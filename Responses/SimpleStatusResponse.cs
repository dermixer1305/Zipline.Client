namespace Zipline.Client.Responses;

/// <summary>
/// Generic status response.
/// </summary>
public sealed class SimpleStatusResponse
{
    /// <summary>
    /// Status message.
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Success flag if provided by the API.
    /// </summary>
    public bool? Success { get; set; }
}
