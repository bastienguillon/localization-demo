using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Web.Models;

public sealed record ProductDto(int Id, string Name, string? Description, decimal UsdPrice, ProductCategory Category);