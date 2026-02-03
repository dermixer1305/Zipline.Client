using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Internal;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

internal sealed class MiscApi : IMiscApi
{
    private readonly ZiplineClient _client;

    public MiscApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<HealthcheckResponse> HealthcheckAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<HealthcheckResponse>("api/healthcheck", cancellationToken);

    public Task<SetupStatusResponse> GetSetupStatusAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<SetupStatusResponse>("api/setup", cancellationToken);

    public Task<SetupResponse> SetupAsync(SetupRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<SetupResponse>(HttpMethod.Post, "api/setup", request, cancellationToken);

    public Task<System.Text.Json.JsonElement> GetStatsAsync(StatsQuery? query = null, CancellationToken cancellationToken = default)
    {
        var builder = new QueryStringBuilder();
        if (query is not null)
        {
            builder.Add("from", query.From);
            builder.Add("to", query.To);
        }

        return _client.GetAsync<System.Text.Json.JsonElement>($"api/stats{builder.ToQueryString()}", cancellationToken);
    }

    public Task<VersionResponse> GetVersionAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<VersionResponse>("api/version", cancellationToken);
}
