using System;
using System.IO;

namespace Zipline.Client.Requests;

/// <summary>
/// File payload for uploads.
/// </summary>
public sealed class UploadFile
{
    /// <summary>
    /// File name sent to the server.
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Stream containing file content.
    /// </summary>
    public Stream Content { get; set; } = Stream.Null;

    /// <summary>
    /// Optional content type.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Creates an upload file from a Base64 string.
    /// </summary>
    public static UploadFile FromBase64(string fileName, string base64, string? contentType = null)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("File name must be provided.", nameof(fileName));
        }

        if (string.IsNullOrWhiteSpace(base64))
        {
            throw new ArgumentException("Base64 content must be provided.", nameof(base64));
        }

        var bytes = Convert.FromBase64String(base64);
        return new UploadFile
        {
            FileName = fileName,
            Content = new MemoryStream(bytes),
            ContentType = contentType
        };
    }
}
