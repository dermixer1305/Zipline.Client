namespace Zipline.Client.Requests;

/// <summary>
/// Query parameters for user listing.
/// </summary>
public sealed class UserListQuery
{
    /// <summary>
    /// Page number (required by the API).
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Field to sort by.
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Sort order (ASC/DESC).
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// Filter by role or other values.
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
