using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

/// <summary>
/// Server-level endpoints.
/// </summary>
public interface IServerApi
{
    /// <summary>
    /// Returns public server information.
    /// </summary>
    Task<JsonElement> GetPublicAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns server settings.
    /// </summary>
    Task<JsonElement> GetSettingsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates server settings.
    /// </summary>
    Task<JsonElement> UpdateSettingsAsync(JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns web settings.
    /// </summary>
    Task<JsonElement> GetWebSettingsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates web settings.
    /// </summary>
    Task<JsonElement> UpdateWebSettingsAsync(JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns available themes.
    /// </summary>
    Task<JsonElement> GetThemesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Requeries total size.
    /// </summary>
    Task<JsonElement> RequerySizeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs the thumbnail worker.
    /// </summary>
    Task<SimpleStatusResponse> RunThumbnailsAsync(ThumbnailsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Scans for zero-sized files.
    /// </summary>
    Task<ClearZerosResponse> ScanZeroFilesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes zero-sized files.
    /// </summary>
    Task<SimpleStatusResponse> DeleteZeroFilesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears temp files.
    /// </summary>
    Task<SimpleStatusResponse> ClearTempAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a public folder and files.
    /// </summary>
    Task<PublicFolderResponse> GetPublicFolderAsync(string id, CancellationToken cancellationToken = default);
}
