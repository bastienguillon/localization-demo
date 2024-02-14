namespace LocalizationDemo.Domain.Abstractions;

public interface ITranslation
{
    public string CultureCode { get; }
    public bool IsDefault { get; }
}

public static class ITranslationExtensions
{
    public static T GetBestTranslation<T>(this IEnumerable<T> translations, string cultureCode) where T : ITranslation
    {
        var enumerable = translations as T[] ?? translations.ToArray();
        return
            enumerable.FirstOrDefault(t => string.Equals(t.CultureCode, cultureCode, StringComparison.OrdinalIgnoreCase)) ??
            enumerable.First(translation => translation.IsDefault);
    }
}