using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Internal;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

internal sealed class UserApi : IUserApi
{
    private readonly ZiplineClient _client;

    public UserApi(ZiplineClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<User> GetAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<User>("api/user", cancellationToken);

    public Task<FileListResponse> GetFilesAsync(FileListQuery query, CancellationToken cancellationToken = default)
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

        return _client.GetAsync<FileListResponse>($"api/user/files{builder.ToQueryString()}", cancellationToken);
    }

    public Task<Models.File> GetFileAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<Models.File>($"api/user/files/{id}", cancellationToken);

    public Task<Models.File> UpdateFileAsync(string id, UpdateFileRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Models.File>(HttpMethod.Patch, $"api/user/files/{id}", request, cancellationToken);

    public Task<Models.File> DeleteFileAsync(string id, CancellationToken cancellationToken = default)
        => _client.DeleteAsync<Models.File>($"api/user/files/{id}", cancellationToken);

    public Task<PasswordCheckResponse> VerifyFilePasswordAsync(string id, PasswordCheckRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<PasswordCheckResponse>(HttpMethod.Post, $"api/user/files/{id}/password", request, cancellationToken);

    public async Task<IReadOnlyList<IncompleteFile>> GetIncompleteFilesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.GetAsync<IncompleteFile[]>("api/user/files/incomplete", cancellationToken).ConfigureAwait(false);
        return result;
    }

    public Task<FileTransactionResponse> UpdateFilesTransactionAsync(FileTransactionUpdateRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<FileTransactionResponse>(HttpMethod.Patch, "api/user/files/transaction", request, cancellationToken);

    public Task<FileTransactionResponse> DeleteFilesTransactionAsync(FileTransactionDeleteRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<FileTransactionResponse>(HttpMethod.Delete, "api/user/files/transaction", request, cancellationToken);

    public async Task<IReadOnlyList<Folder>> GetFoldersAsync(FolderListQuery? query = null, CancellationToken cancellationToken = default)
    {
        var builder = new QueryStringBuilder();
        if (query is not null)
        {
            builder.Add("showFiles", query.ShowFiles);
        }

        var result = await _client.GetAsync<Folder[]>($"api/user/folders{builder.ToQueryString()}", cancellationToken).ConfigureAwait(false);
        return result;
    }

    public Task<Folder> CreateFolderAsync(CreateFolderRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Folder>(HttpMethod.Post, "api/user/folders", request, cancellationToken);

    public Task<Folder> GetFolderAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<Folder>($"api/user/folders/{id}", cancellationToken);

    public Task<Folder> UpdateFolderAsync(string id, UpdateFolderRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Folder>(HttpMethod.Patch, $"api/user/folders/{id}", request, cancellationToken);

    public Task<Folder> AddFileToFolderAsync(string id, FolderAddFileRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Folder>(HttpMethod.Put, $"api/user/folders/{id}", request, cancellationToken);

    public Task<Folder> DeleteFolderAsync(string id, FolderDeleteRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Folder>(HttpMethod.Delete, $"api/user/folders/{id}", request, cancellationToken);

    public async Task<IReadOnlyList<Url>> GetUrlsAsync(UrlListQuery? query = null, CancellationToken cancellationToken = default)
    {
        var builder = new QueryStringBuilder();
        if (query is not null)
        {
            builder.Add("showFiles", query.ShowFiles);
        }

        var result = await _client.GetAsync<Url[]>($"api/user/urls{builder.ToQueryString()}", cancellationToken).ConfigureAwait(false);
        return result;
    }

    public Task<Url> CreateUrlAsync(CreateUrlRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Url>(HttpMethod.Post, "api/user/urls", request, cancellationToken);

    public Task<Url> GetUrlAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<Url>($"api/user/urls/{id}", cancellationToken);

    public Task<Url> UpdateUrlAsync(string id, UpdateUrlRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Url>(HttpMethod.Patch, $"api/user/urls/{id}", request, cancellationToken);

    public Task<Url> DeleteUrlAsync(string id, CancellationToken cancellationToken = default)
        => _client.DeleteAsync<Url>($"api/user/urls/{id}", cancellationToken);

    public Task<PasswordCheckResponse> VerifyUrlPasswordAsync(string id, PasswordCheckRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<PasswordCheckResponse>(HttpMethod.Post, $"api/user/urls/{id}/password", request, cancellationToken);

    public async Task<IReadOnlyList<Tag>> GetTagsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.GetAsync<Tag[]>("api/user/tags", cancellationToken).ConfigureAwait(false);
        return result;
    }

    public Task<Tag> CreateTagAsync(CreateTagRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Tag>(HttpMethod.Post, "api/user/tags", request, cancellationToken);

    public Task<Tag> GetTagAsync(string id, CancellationToken cancellationToken = default)
        => _client.GetAsync<Tag>($"api/user/tags/{id}", cancellationToken);

    public Task<Tag> UpdateTagAsync(string id, UpdateTagRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<Tag>(HttpMethod.Patch, $"api/user/tags/{id}", request, cancellationToken);

    public Task<Tag> DeleteTagAsync(string id, CancellationToken cancellationToken = default)
        => _client.DeleteAsync<Tag>($"api/user/tags/{id}", cancellationToken);

    public Task<TotpSetupResponse> GetTotpAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<TotpSetupResponse>("api/user/mfa/totp", cancellationToken);

    public Task<User> VerifyTotpAsync(TotpVerifyRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<User>(HttpMethod.Post, "api/user/mfa/totp", request, cancellationToken);

    public async Task<IReadOnlyList<RecentFile>> GetRecentAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.GetAsync<RecentFile[]>("api/user/recent", cancellationToken).ConfigureAwait(false);
        return result;
    }

    public Task<SessionsResponse> GetSessionsAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<SessionsResponse>("api/user/sessions", cancellationToken);

    public Task<SessionsResponse> DeleteSessionAsync(DeleteSessionRequest request, CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<SessionsResponse>(HttpMethod.Delete, "api/user/sessions", request, cancellationToken);

    public Task<TokenResponse> GetTokenAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<TokenResponse>("api/user/token", cancellationToken);

    public Task<AuthResponse> RefreshTokenAsync(CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<AuthResponse>(HttpMethod.Patch, "api/user/token", payload: null, cancellationToken);

    public Task<System.Text.Json.JsonElement> GetStatsAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<System.Text.Json.JsonElement>("api/user/stats", cancellationToken);

    public Task<System.Text.Json.JsonElement> GetExportsAsync(CancellationToken cancellationToken = default)
        => _client.GetAsync<System.Text.Json.JsonElement>("api/user/export", cancellationToken);

    public Task<System.Text.Json.JsonElement> StartExportAsync(CancellationToken cancellationToken = default)
        => _client.SendJsonAsync<System.Text.Json.JsonElement>(HttpMethod.Post, "api/user/export", payload: null, cancellationToken);

    public async Task<byte[]> DownloadExportAsync(string id, CancellationToken cancellationToken = default)
    {
        using var response = await _client.SendRawAsync(HttpMethod.Get, $"api/user/export/{id}", null, null, cancellationToken).ConfigureAwait(false);
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory, cancellationToken).ConfigureAwait(false);
        return memory.ToArray();
    }

    public async Task<byte[]> GetAvatarAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _client.SendRawAsync(HttpMethod.Get, "api/user/avatar", null, null, cancellationToken).ConfigureAwait(false);
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory, cancellationToken).ConfigureAwait(false);
        return memory.ToArray();
    }
}
