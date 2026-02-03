namespace Zipline.Client.Requests;

/// <summary>
/// Quota configuration for a user.
/// </summary>
public sealed class UserQuotaRequest
{
    /// <summary>
    /// Quota type (BY_BYTES, BY_FILES, NONE).
    /// </summary>
    public string? FilesType { get; set; }

    /// <summary>
    /// Maximum bytes allowed.
    /// </summary>
    public long? MaxBytes { get; set; }

    /// <summary>
    /// Maximum file count allowed.
    /// </summary>
    public int? MaxFiles { get; set; }

    /// <summary>
    /// Maximum URLs allowed.
    /// </summary>
    public int? MaxUrls { get; set; }
}
