using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zipline.Client.Responses;

/// <summary>
/// Response payload for version information.
/// </summary>
public sealed class VersionResponse
{
    /// <summary>
    /// Whether the version result was cached.
    /// </summary>
    public bool? Cached { get; set; }

    /// <summary>
    /// Version data.
    /// </summary>
    public VersionInfo? Data { get; set; }

    /// <summary>
    /// Additional fields returned by the server.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
}

/// <summary>
/// Version information payload.
/// </summary>
public sealed class VersionInfo
{
    /// <summary>
    /// Whether the instance is ahead of upstream.
    /// </summary>
    public bool? IsUpstream { get; set; }

    /// <summary>
    /// Whether this is a release build.
    /// </summary>
    public bool? IsRelease { get; set; }

    /// <summary>
    /// Version string if provided.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Commit hash if provided.
    /// </summary>
    public string? Commit { get; set; }

    /// <summary>
    /// Additional fields returned by the server.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalFields { get; set; }
}
