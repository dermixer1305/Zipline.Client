namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for creating a tag.
/// </summary>
public sealed class CreateTagRequest
{
    /// <summary>
    /// Tag name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tag color (hex or named).
    /// </summary>
    public string? Color { get; set; }
}
