namespace CQRS.Model;

public class GetProductsQuery
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } 
    public int PageNumber { get; set; } 
    public int PageSize { get; set; } 
    public string SearchTerm { get; set; } = string.Empty;
    public decimal? MinPrice { get; set; } 
    public decimal? MaxPrice { get; set; }
}