using System;
using System.Text.Json.Serialization;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for updating a folder.
/// </summary>
public sealed class UpdateFolderRequest
{
    /// <summary>
    /// New folder name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Optional folder password.
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
    /// Whether the folder is public.
    /// </summary>
    [JsonPropertyName("public")]
    public bool? IsPublic { get; set; }
}
