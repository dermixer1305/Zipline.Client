namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for adding a file to a folder.
/// </summary>
public sealed class FolderAddFileRequest
{
    /// <summary>
    /// File id to add.
    /// </summary>
    public string File { get; set; } = string.Empty;
}
