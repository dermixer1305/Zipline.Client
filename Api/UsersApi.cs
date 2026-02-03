using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Internal;

namespace Zipline.Client.Api;

internal sealed class UsersApi : IUsersApi
{
    private readonly ZiplineClient _client;

    public UsersApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<User[]> GetUsersAsync(UserListQuery query, CancellationToken cancellationToken = default)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var builder = new QueryStringBuilder();
        builder.Add("page", query.Page);
        builder.Add("sort", query.Sort);
        builder.Add("order", query.Order);
        builder.Add("filter", query.Filter);
        builder.Add("per_page", query.PerPage);
        builder.Add("search_field", query.SearchField);
        builder.Add("search_query", query.SearchQuery);

        return _client.GetAsync<User[]>($"api/users{builder.ToQueryString()}", cancellationToken);
    }

    public Task<User> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<User>(HttpMethod.Post, "api/users", request, cancellationToken);

    public Task<User> GetUserAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<User>($"api/users/{id}", cancellationToken);

    public Task<User> UpdateUserAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<User>(HttpMethod.Patch, $"api/users/{id}", request, cancellationToken);

    public Task<User> DeleteUserAsync(string id, DeleteUserRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<User>(HttpMethod.Delete, $"api/users/{id}", request, cancellationToken);
}
