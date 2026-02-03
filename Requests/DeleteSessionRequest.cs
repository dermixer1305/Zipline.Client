namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for deleting a session.
/// </summary>
public sealed class DeleteSessionRequest
{
    /// <summary>
    /// Session id to delete.
    /// </summary>
    public string SessionId { get; set; } = string.Empty;
}
