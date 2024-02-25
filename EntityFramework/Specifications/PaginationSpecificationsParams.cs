namespace PizzaMauiApp.API.Core.EntityFramework.Specifications;

public class PaginationSpecificationsParams
{
    public const int MAX_PAGE_SIZE = 20;
    public int PageIndex { get; set; } = 1;

    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
    }
    
    public string? SortBy { get; set; }
    
    private string? _searchCriteria;
    public string? SearchCriteria { get => _searchCriteria; set => _searchCriteria = value?.ToLower(); }
}