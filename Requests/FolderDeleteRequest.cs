namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for deleting a folder.
/// </summary>
public sealed class FolderDeleteRequest
{
    /// <summary>
    /// If true, delete files in the folder as well.
    /// </summary>
    public bool? DeleteFiles { get; set; }
}
