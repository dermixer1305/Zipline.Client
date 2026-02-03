using System;

namespace Zipline.Client.Requests;

/// <summary>
/// Query parameters for stats.
/// </summary>
public sealed class StatsQuery
{
    /// <summary>
    /// Start timestamp for stats range.
    /// </summary>
    public DateTimeOffset? From { get; set; }

    /// <summary>
    /// End timestamp for stats range.
    /// </summary>
    public DateTimeOffset? To { get; set; }
}
