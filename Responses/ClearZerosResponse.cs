using System.Text.Json;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for zero-sized file scans.
/// </summary>
public sealed class ClearZerosResponse
{
    /// <summary>
    /// Files found with size zero.
    /// </summary>
    public JsonElement? Files { get; set; }
}
