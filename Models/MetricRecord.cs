using System;

namespace Zipline.Client.Models;

/// <summary>
/// Metrics record for stats.
/// </summary>
public sealed class MetricRecord
{
    /// <summary>
    /// Record id.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Timestamp when the record was created.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the record was updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Metric data.
    /// </summary>
    public MetricData? Data { get; set; }
}

/// <summary>
/// Metric data payload.
/// </summary>
public sealed class MetricData
{
    /// <summary>
    /// User count.
    /// </summary>
    public int? Users { get; set; }

    /// <summary>
    /// File count.
    /// </summary>
    public int? Files { get; set; }

    /// <summary>
    /// File view count.
    /// </summary>
    public int? FileViews { get; set; }
}
