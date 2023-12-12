namespace LocalizationDemo.Domain.Abstractions;

public interface ITranslation
{
    public string CultureCode { get; }
    public bool IsDefault { get; }
}
