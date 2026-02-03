using Zipline.Client.Models;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for public folder access.
/// </summary>
public sealed class PublicFolderResponse
{
    /// <summary>
    /// Folder metadata.
    /// </summary>
    public Folder? Folder { get; set; }

    /// <summary>
    /// Files contained in the folder.
    /// </summary>
    public Models.File[]? Files { get; set; }
}
