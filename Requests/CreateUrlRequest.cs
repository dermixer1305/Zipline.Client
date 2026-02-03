using System;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for creating a URL.
/// </summary>
public sealed class CreateUrlRequest
{
    /// <summary>
    /// Destination URL.
    /// </summary>
    public string Destination { get; set; } = string.Empty;

    /// <summary>
    /// Optional vanity code.
    /// </summary>
    public string? Vanity { get; set; }

    /// <summary>
    /// Optional password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Optional expiration timestamp.
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; set; }

    /// <summary>
    /// Optional maximum view count.
    /// </summary>
    public int? MaxViews { get; set; }

    /// <summary>
    /// Whether the URL is enabled.
    /// </summary>
    public bool? Enabled { get; set; }
}
