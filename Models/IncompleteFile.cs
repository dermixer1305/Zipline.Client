using System;
using System.Text.Json;

namespace Zipline.Client.Models;

/// <summary>
/// Incomplete upload metadata.
/// </summary>
public sealed class IncompleteFile
{
    /// <summary>
    /// Incomplete file id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Total chunks expected.
    /// </summary>
    public int ChunksTotal { get; set; }

    /// <summary>
    /// Chunks completed.
    /// </summary>
    public int ChunksComplete { get; set; }

    /// <summary>
    /// Optional metadata payload.
    /// </summary>
    public JsonElement? Metadata { get; set; }

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
