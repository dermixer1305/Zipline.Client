using System;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for uploads.
/// </summary>
public sealed class UploadResponse
{
    /// <summary>
    /// Uploaded file details.
    /// </summary>
    public UploadedFileInfo[] Files { get; set; } = Array.Empty<UploadedFileInfo>();

    /// <summary>
    /// Deletion timestamp, if any.
    /// </summary>
    public DateTimeOffset? DeletesAt { get; set; }

    /// <summary>
    /// Flags indicating assumed MIME types.
    /// </summary>
    public bool[]? AssumedMimetypes { get; set; }
}

/// <summary>
/// Metadata for an uploaded file.
/// </summary>
public sealed class UploadedFileInfo
{
    /// <summary>
    /// File id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// File type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// URL to access the file.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Indicates pending processing.
    /// </summary>
    public bool? Pending { get; set; }
}
