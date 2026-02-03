using System;

namespace Zipline.Client.Models;

/// <summary>
/// Invite metadata.
/// </summary>
public sealed class Invite
{
    /// <summary>
    /// Invite id.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Invite code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Inviter user id.
    /// </summary>
    public string? InviterId { get; set; }

    /// <summary>
    /// Current uses.
    /// </summary>
    public int Uses { get; set; }

    /// <summary>
    /// Max uses.
    /// </summary>
    public int? MaxUses { get; set; }

    /// <summary>
    /// Expiration timestamp.
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}
