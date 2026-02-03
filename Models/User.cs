using System;
using System.Text.Json;

namespace Zipline.Client.Models;

/// <summary>
/// User metadata.
/// </summary>
public sealed class User
{
    /// <summary>
    /// User id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// User role (e.g. ADMIN, USER).
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// View preferences.
    /// </summary>
    public UserViewSettings? View { get; set; }

    /// <summary>
    /// Active session ids.
    /// </summary>
    public string[]? Sessions { get; set; }

    /// <summary>
    /// OAuth providers linked to this user.
    /// </summary>
    public JsonElement[]? OauthProviders { get; set; }

    /// <summary>
    /// TOTP secret, if returned by the API.
    /// </summary>
    public string? TotpSecret { get; set; }

    /// <summary>
    /// User quota settings.
    /// </summary>
    public UserQuota? Quota { get; set; }

    /// <summary>
    /// Passkeys (if returned by the API).
    /// </summary>
    public JsonElement[]? Passkeys { get; set; }

    /// <summary>
    /// Avatar data or URL (server-dependent).
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}

/// <summary>
/// User view preferences.
/// </summary>
public sealed class UserViewSettings
{
    /// <summary>
    /// File view mode (grid/list).
    /// </summary>
    public string? Files { get; set; }

    /// <summary>
    /// Whether to show NSFW content.
    /// </summary>
    public bool? Nsfw { get; set; }

    /// <summary>
    /// Whether to autoplay videos.
    /// </summary>
    public bool? Autoplay { get; set; }

    /// <summary>
    /// Pagination size.
    /// </summary>
    public int? Pagination { get; set; }
}

/// <summary>
/// User quota settings.
/// </summary>
public sealed class UserQuota
{
    /// <summary>
    /// Quota type (BY_BYTES, BY_FILES, NONE).
    /// </summary>
    public string? FilesType { get; set; }

    /// <summary>
    /// Max bytes allowed.
    /// </summary>
    public long? MaxBytes { get; set; }

    /// <summary>
    /// Max files allowed.
    /// </summary>
    public int? MaxFiles { get; set; }

    /// <summary>
    /// Max URLs allowed.
    /// </summary>
    public int? MaxUrls { get; set; }
}
