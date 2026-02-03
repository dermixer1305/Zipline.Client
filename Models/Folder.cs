using System;

namespace Zipline.Client.Models;

/// <summary>
/// Folder metadata.
/// </summary>
public sealed class Folder
{
    /// <summary>
    /// Folder id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Folder name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Whether the folder is public.
    /// </summary>
    public bool Public { get; set; }

    /// <summary>
    /// Whether the folder is password protected.
    /// </summary>
    public bool? Password { get; set; }

    /// <summary>
    /// Optional folder description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Optional list of files when requested.
    /// </summary>
    public File[]? Files { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}
