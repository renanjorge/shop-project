namespace shop.domain.Parameters;

public class PagedListParameters
{
    private int _pageNumber = 1;
    public int PageNumber
    {
        get { return _pageNumber; }
        set { _pageNumber = value < 1 ? _pageNumber : value; }
    }

    private const int maxPageSize = 100;
    private int _pageSize = 10;
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
    }

    public int Skip() => (_pageNumber - 1) * PageSize;

    public int Take() => PageSize;
}