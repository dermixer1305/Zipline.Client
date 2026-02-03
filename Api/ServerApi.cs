using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Internal;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

internal sealed class ServerApi : IServerApi
{
    private readonly ZiplineClient _client;

    public ServerApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<JsonElement> GetPublicAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<JsonElement>("api/server/public", cancellationToken);

    public Task<JsonElement> GetSettingsAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<JsonElement>("api/server/settings", cancellationToken);

    public Task<JsonElement> UpdateSettingsAsync(JsonElement payload, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<JsonElement>(HttpMethod.Patch, "api/server/settings", payload, cancellationToken);

    public Task<JsonElement> GetWebSettingsAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<JsonElement>("api/server/settings/web", cancellationToken);

    public Task<JsonElement> UpdateWebSettingsAsync(JsonElement payload, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<JsonElement>(HttpMethod.Patch, "api/server/settings/web", payload, cancellationToken);

    public Task<JsonElement> GetThemesAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<JsonElement>("api/server/themes", cancellationToken);

    public Task<JsonElement> RequerySizeAsync(CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<JsonElement>(HttpMethod.Post, "api/server/requery_size", payload: null, cancellationToken);

    public Task<SimpleStatusResponse> RunThumbnailsAsync(ThumbnailsRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<SimpleStatusResponse>(HttpMethod.Post, "api/server/thumbnails", request, cancellationToken);

    public Task<ClearZerosResponse> ScanZeroFilesAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<ClearZerosResponse>("api/server/clear_zeros", cancellationToken);

    public Task<SimpleStatusResponse> DeleteZeroFilesAsync(CancellationToken cancellationToken = default)
        => _client.DeleteAsync<SimpleStatusResponse>("api/server/clear_zeros", cancellationToken);

    public Task<SimpleStatusResponse> ClearTempAsync(CancellationToken cancellationToken = default)
        => _client.DeleteAsync<SimpleStatusResponse>("api/server/clear_temp", cancellationToken);

    public Task<PublicFolderResponse> GetPublicFolderAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<PublicFolderResponse>($"api/server/folder/{id}", cancellationToken);
}
