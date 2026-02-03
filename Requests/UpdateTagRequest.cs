namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for updating a tag.
/// </summary>
public sealed class UpdateTagRequest
{
    /// <summary>
    /// Tag name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Tag color (hex or named).
    /// </summary>
    public string? Color { get; set; }
}
