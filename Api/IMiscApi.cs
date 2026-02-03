using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

/// <summary>
/// Miscellaneous endpoints.
/// </summary>
public interface IMiscApi
{
    /// <summary>
    /// Returns health status.
    /// </summary>
    Task<HealthcheckResponse> HealthcheckAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns setup status.
    /// </summary>
    Task<SetupStatusResponse> GetSetupStatusAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs first-time setup.
    /// </summary>
    Task<SetupResponse> SetupAsync(SetupRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns server stats.
    /// </summary>
    Task<System.Text.Json.JsonElement> GetStatsAsync(StatsQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns server version information.
    /// </summary>
    Task<VersionResponse> GetVersionAsync(CancellationToken cancellationToken = default);
}
