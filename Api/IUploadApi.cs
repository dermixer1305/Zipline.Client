using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

/// <summary>
/// Upload endpoints.
/// </summary>
public interface IUploadApi
{
    /// <summary>
    /// Uploads one or more files via multipart/form-data.
    /// </summary>
    Task<UploadResponse> UploadAsync(IEnumerable<UploadFile> files, UploadOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a single file from a Base64 string.
    /// </summary>
    Task<UploadResponse> UploadBase64Async(string fileName, string base64, string? contentType = null, UploadOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a partial/chunked payload.
    /// </summary>
    Task<UploadResponse> UploadPartialAsync(HttpContent content, IDictionary<string, string>? headers = null, CancellationToken cancellationToken = default);
}
