using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Models;
using Zipline.Client.Requests;
using Zipline.Client.Responses;

namespace Zipline.Client.Api;

/// <summary>
/// Endpoints for the currently authenticated user.
/// </summary>
public interface IUserApi
{
    /// <summary>
    /// Gets the current user profile.
    /// </summary>
    Task<User> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists files for the current user.
    /// </summary>
    Task<FileListResponse> GetFilesAsync(FileListQuery query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a file by id.
    /// </summary>
    Task<Models.File> GetFileAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a file.
    /// </summary>
    Task<Models.File> UpdateFileAsync(string id, UpdateFileRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a file.
    /// </summary>
    Task<Models.File> DeleteFileAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies a file password.
    /// </summary>
    Task<PasswordCheckResponse> VerifyFilePasswordAsync(string id, PasswordCheckRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists incomplete uploads.
    /// </summary>
    Task<IReadOnlyList<IncompleteFile>> GetIncompleteFilesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates multiple files in a transaction.
    /// </summary>
    Task<FileTransactionResponse> UpdateFilesTransactionAsync(FileTransactionUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes multiple files in a transaction.
    /// </summary>
    Task<FileTransactionResponse> DeleteFilesTransactionAsync(FileTransactionDeleteRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists folders.
    /// </summary>
    Task<IReadOnlyList<Folder>> GetFoldersAsync(FolderListQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a folder.
    /// </summary>
    Task<Folder> CreateFolderAsync(CreateFolderRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a folder by id.
    /// </summary>
    Task<Folder> GetFolderAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a folder.
    /// </summary>
    Task<Folder> UpdateFolderAsync(string id, UpdateFolderRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a file to a folder.
    /// </summary>
    Task<Folder> AddFileToFolderAsync(string id, FolderAddFileRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a folder.
    /// </summary>
    Task<Folder> DeleteFolderAsync(string id, FolderDeleteRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists URLs.
    /// </summary>
    Task<IReadOnlyList<Url>> GetUrlsAsync(UrlListQuery? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a URL.
    /// </summary>
    Task<Url> CreateUrlAsync(CreateUrlRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a URL by id.
    /// </summary>
    Task<Url> GetUrlAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a URL.
    /// </summary>
    Task<Url> UpdateUrlAsync(string id, UpdateUrlRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a URL.
    /// </summary>
    Task<Url> DeleteUrlAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies a URL password.
    /// </summary>
    Task<PasswordCheckResponse> VerifyUrlPasswordAsync(string id, PasswordCheckRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists tags.
    /// </summary>
    Task<IReadOnlyList<Tag>> GetTagsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a tag.
    /// </summary>
    Task<Tag> CreateTagAsync(CreateTagRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a tag by id.
    /// </summary>
    Task<Tag> GetTagAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a tag.
    /// </summary>
    Task<Tag> UpdateTagAsync(string id, UpdateTagRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a tag.
    /// </summary>
    Task<Tag> DeleteTagAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts TOTP setup for MFA.
    /// </summary>
    Task<TotpSetupResponse> GetTotpAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies TOTP and enables MFA.
    /// </summary>
    Task<User> VerifyTotpAsync(TotpVerifyRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists recent files.
    /// </summary>
    Task<IReadOnlyList<RecentFile>> GetRecentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists active sessions.
    /// </summary>
    Task<SessionsResponse> GetSessionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specific session.
    /// </summary>
    Task<SessionsResponse> DeleteSessionAsync(DeleteSessionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the API token for the current user.
    /// </summary>
    Task<TokenResponse> GetTokenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Regenerates the API token for the current user.
    /// </summary>
    Task<AuthResponse> RefreshTokenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns server-side stats for the current user.
    /// </summary>
    Task<System.Text.Json.JsonElement> GetStatsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists exports.
    /// </summary>
    Task<System.Text.Json.JsonElement> GetExportsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a new export.
    /// </summary>
    Task<System.Text.Json.JsonElement> StartExportAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads a specific export file.
    /// </summary>
    Task<byte[]> DownloadExportAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads the current user avatar (if available).
    /// </summary>
    Task<byte[]> GetAvatarAsync(CancellationToken cancellationToken = default);
}
