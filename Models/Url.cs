using System;
using System.Text.Json;

namespace Zipline.Client.Models;

/// <summary>
/// Short URL metadata.
/// </summary>
public sealed class Url
{
    /// <summary>
    /// URL id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Short code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Optional vanity path.
    /// </summary>
    public string? Vanity { get; set; }

    /// <summary>
    /// Destination URL.
    /// </summary>
    public string Destination { get; set; } = string.Empty;

    /// <summary>
    /// Whether the URL is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Number of views.
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    /// Maximum view count.
    /// </summary>
    public int? MaxViews { get; set; }

    /// <summary>
    /// Password indicator or value (server-dependent).
    /// </summary>
    public JsonElement? Password { get; set; }

    /// <summary>
    /// Owner user id.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}
