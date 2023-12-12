using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Web.Models;

public record ProductDto(int Id, string Name, string? Description, decimal UsdPrice, ProductCategory Category);