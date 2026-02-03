using System;

namespace Zipline.Client.Models;

/// <summary>
/// Tag metadata.
/// </summary>
public sealed class Tag
{
    /// <summary>
    /// Tag id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Tag name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tag color.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Files associated with the tag (if returned by the API).
    /// </summary>
    public TagFileReference[]? Files { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}

/// <summary>
/// Lightweight file reference used in tag responses.
/// </summary>
public sealed class TagFileReference
{
    /// <summary>
    /// File id.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}
