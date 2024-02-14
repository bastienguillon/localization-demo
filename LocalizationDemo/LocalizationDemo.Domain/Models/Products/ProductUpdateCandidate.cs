namespace LocalizationDemo.Domain.Models.Products;

public record ProductUpdateCandidate
{
    public ProductCategory? Category { get; init; }
}