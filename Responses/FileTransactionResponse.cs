namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for file transaction operations.
/// </summary>
public sealed class FileTransactionResponse
{
    /// <summary>
    /// Number of files affected.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Operation name.
    /// </summary>
    public string? Name { get; set; }
}
