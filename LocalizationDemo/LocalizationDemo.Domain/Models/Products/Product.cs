using LocalizationDemo.Domain.Abstractions;

namespace LocalizationDemo.Domain.Models.Products;

public sealed class Product
{
    public int Id { get; set; }

    public decimal UsdPrice { get; set; }

    public ProductCategory Category { get; set; }

    public sealed class ProductTranslation : ITranslation
    {
        public int ProductId { get; set; }
        public string CultureCode { get; set; }
        public bool IsDefault { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public IEnumerable<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
}