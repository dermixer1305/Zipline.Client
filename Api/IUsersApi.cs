using System.Threading;
using System.Threading.Tasks;
using Zipline.Client.Models;
using Zipline.Client.Requests;

namespace Zipline.Client.Api;

/// <summary>
/// Admin endpoints for managing users.
/// </summary>
public interface IUsersApi
{
    /// <summary>
    /// Lists users.
    /// </summary>
    Task<User[]> GetUsersAsync(UserListQuery query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    Task<User> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a user by id.
    /// </summary>
    Task<User> GetUserAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a user.
    /// </summary>
    Task<User> UpdateUserAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    Task<User> DeleteUserAsync(string id, DeleteUserRequest request, CancellationToken cancellationToken = default);
}
