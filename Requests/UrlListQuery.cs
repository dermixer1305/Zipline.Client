namespace Zipline.Client.Requests;

/// <summary>
/// Query parameters for URL listing.
/// </summary>
public sealed class UrlListQuery
{
    /// <summary>
    /// If true, include files in each URL entry.
    /// </summary>
    public bool? ShowFiles { get; set; }
}
