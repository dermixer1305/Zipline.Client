namespace Zipline.Client.Requests;

/// <summary>
/// Query parameters for folder listing.
/// </summary>
public sealed class FolderListQuery
{
    /// <summary>
    /// If true, include files in each folder.
    /// </summary>
    public bool? ShowFiles { get; set; }
}
