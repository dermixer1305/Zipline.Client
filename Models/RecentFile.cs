using System;
using System.Text.Json.Serialization;

namespace Zipline.Client.Models;

/// <summary>
/// Recent file entry.
/// </summary>
public sealed class RecentFile
{
    /// <summary>
    /// Recent entry id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Associated file.
    /// </summary>
    public File? File { get; set; }

    /// <summary>
    /// MIME type.
    /// </summary>
    [JsonPropertyName("mimetype")]
    public string? MimeType { get; set; }

    /// <summary>
    /// URL to access the file.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Number of views.
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    /// Max view count.
    /// </summary>
    public int? MaxViews { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Expiration timestamp.
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; set; }
}
