using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for updating a file.
/// </summary>
public sealed class UpdateFileRequest
{
    /// <summary>
    /// New file name without extension.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// New file extension.
    /// </summary>
    public string? Extension { get; set; }

    /// <summary>
    /// Optional folder id to move the file into.
    /// </summary>
    public string? FolderId { get; set; }

    /// <summary>
    /// Optional file password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Optional maximum view count.
    /// </summary>
    public int? MaxViews { get; set; }

    /// <summary>
    /// Optional expiration timestamp.
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; set; }

    /// <summary>
    /// Optional favorite flag.
    /// </summary>
    public bool? Favorite { get; set; }

    /// <summary>
    /// Optional tag ids to set.
    /// </summary>
    public string[]? Tags { get; set; }

    /// <summary>
    /// Optional per-file metadata.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
}
