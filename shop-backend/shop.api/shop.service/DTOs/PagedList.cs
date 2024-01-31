namespace shop.service.DTOs;

public class PagedList<TModel> where TModel : class
{
    public IEnumerable<TModel> Data { get; set; }
    public int CurrentPage { get; private set; }
    public int? NextPage { get; private set; }
    public int RecordsTotal { get; set; }
    public int RecordsFiltered { get; set; }

    public PagedList(IEnumerable<TModel> data, int currentPage, int pageSize, int total)
    {
        Data = data;
        RecordsTotal = total;
        RecordsFiltered = data.Count();
        CurrentPage = currentPage;
        NextPage = pageSize * currentPage <= total ? currentPage + 1 : null;
    }
}