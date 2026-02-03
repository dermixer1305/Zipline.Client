using System;

namespace Zipline.Client.Requests;

/// <summary>
/// Request payload for creating an invite.
/// </summary>
public sealed class CreateInviteRequest
{
    /// <summary>
    /// Max number of uses for the invite.
    /// </summary>
    public int? MaxUses { get; set; }

    /// <summary>
    /// Optional expiration timestamp.
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; set; }
}
