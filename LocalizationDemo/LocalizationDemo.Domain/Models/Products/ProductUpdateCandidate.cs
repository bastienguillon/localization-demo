namespace LocalizationDemo.Domain.Models.Products;

public record ProductUpdateCandidate
{
    public Dictionary<string, ProductTranslationPayload>? Translations { get; init; }
    public ProductCategory? Category { get; init; }
}