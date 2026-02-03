using System.Collections.Generic;

namespace Zipline.Client.Requests;

/// <summary>
/// Optional upload headers and form fields.
/// </summary>
public sealed class UploadOptions
{
    /// <summary>
    /// Extra headers to send with the upload request.
    /// </summary>
    public Dictionary<string, string?> Headers { get; } = new();

    /// <summary>
    /// Extra form fields to include in the multipart request.
    /// </summary>
    public Dictionary<string, string?> Fields { get; } = new();
}
