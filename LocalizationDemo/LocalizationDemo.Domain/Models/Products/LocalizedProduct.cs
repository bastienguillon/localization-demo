using LocalizationDemo.Domain.Abstractions;

namespace LocalizationDemo.Domain.Models.Products;

public sealed class LocalizedProduct
{
    public int Id { get; set; }
    
    public decimal UsdPrice { get; set; }
    public ProductCategory Category { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
}