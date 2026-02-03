using System;
using System.Net.Http;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zipline.Client.Api;

namespace Zipline.Client;

/// <summary>
/// Main entry point for Zipline API access.
/// </summary>
public interface IZiplineClient : IDisposable
{
    /// <summary>
    /// Access authentication endpoints.
    /// </summary>
    IAuthApi Auth { get; }

    /// <summary>
    /// Access current-user endpoints.
    /// </summary>
    IUserApi User { get; }

    /// <summary>
    /// Access admin/user management endpoints.
    /// </summary>
    IUsersApi Users { get; }

    /// <summary>
    /// Access server-level endpoints.
    /// </summary>
    IServerApi Server { get; }

    /// <summary>
    /// Access upload endpoints.
    /// </summary>
    IUploadApi Upload { get; }

    /// <summary>
    /// Access miscellaneous endpoints (health, stats, version, setup).
    /// </summary>
    IMiscApi Misc { get; }

    /// <summary>
    /// Sends a raw request to the Zipline API.
    /// </summary>
    Task<HttpResponseMessage> SendRawAsync(HttpMethod method, string path, HttpContent? content = null, IDictionary<string, string?>? headers = null, CancellationToken cancellationToken = default);
}
