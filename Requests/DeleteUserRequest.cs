namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for deleting a user.
/// </summary>
public sealed class DeleteUserRequest
{
    /// <summary>
    /// Optional user id to transfer ownership to.
    /// </summary>
    public string? TransferTo { get; set; }
}
