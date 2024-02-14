namespace LocalizationDemo.Web.Models;

public sealed record ShoppingCartDto(Guid Id, IEnumerable<ProductDto> Products);