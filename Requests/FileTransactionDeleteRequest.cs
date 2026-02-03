using System;
using System.Text.Json.Serialization;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for deleting multiple files in a transaction.
/// </summary>
public sealed class FileTransactionDeleteRequest
{
    /// <summary>
    /// File ids to delete.
    /// </summary>
    [JsonPropertyName("files")]
    public string[] Files { get; set; } = Array.Empty<string>();
}
