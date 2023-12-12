namespace LocalizationDemo.Domain.Models;

public static class ContentCulture
{
    public const string Default = "en-US";

    public static readonly IReadOnlyCollection<string> All = new HashSet<string>
    {
        "fr-FR",
        "en-US",
        "es-ES",
        "it-IT",
        "de-DE",
        "nl-NL",
        "nl-BE",
        "pt-PT"
    };
}
