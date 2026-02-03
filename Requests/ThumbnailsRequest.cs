namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for running thumbnail worker.
/// </summary>
public sealed class ThumbnailsRequest
{
    /// <summary>
    /// Whether to re-run for already processed files.
    /// </summary>
    public bool? Rerun { get; set; }
}
