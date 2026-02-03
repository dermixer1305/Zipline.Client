using System;
using Zipline.Client.Models;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for file listing.
/// </summary>
public sealed class FileListResponse
{
    /// <summary>
    /// Page of files.
    /// </summary>
    public Models.File[] Page { get; set; } = Array.Empty<Models.File>();

    /// <summary>
    /// Total file count.
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Total page count.
    /// </summary>
    public int Pages { get; set; }

    /// <summary>
    /// Search metadata (if applicable).
    /// </summary>
    public FileSearchInfo? Search { get; set; }
}

/// <summary>
/// Search metadata for file listing.
/// </summary>
public sealed class FileSearchInfo
{
    /// <summary>
    /// Field used for search.
    /// </summary>
    public string? Field { get; set; }

    /// <summary>
    /// Query string.
    /// </summary>
    public string? Query { get; set; }
}
