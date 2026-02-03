namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for setup status.
/// </summary>
public sealed class SetupStatusResponse
{
    /// <summary>
    /// Whether this is the first setup.
    /// </summary>
    public bool FirstSetup { get; set; }
}
