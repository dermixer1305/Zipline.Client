namespace Zipline.Client.Requests;

/// <summary>
/// Query parameters for file listing.
/// </summary>
public sealed class FileListQuery
{
    /// <summary>
    /// Page number (required by the API).
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Field to sort by (e.g. createdAt).
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Sort order (ASC/DESC).
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// Filter by type or other server-defined values.
    /// </summary>
    public string? Filter { get; set; }

    /// <summary>
    /// Items per page.
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Field to search by.
    /// </summary>
    public string? SearchField { get; set; }

    /// <summary>
    /// Search query.
    /// </summary>
    public string? SearchQuery { get; set; }
}
