using System;
using System.Text.Json.Serialization;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for updating multiple files in a transaction.
/// </summary>
public sealed class FileTransactionUpdateRequest
{
    /// <summary>
    /// File ids to update.
    /// </summary>
    [JsonPropertyName("files")]
    public string[] Files { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Update data to apply to all files.
    /// </summary>
    [JsonPropertyName("data")]
    public UpdateFileRequest Data { get; set; } = new();
}
