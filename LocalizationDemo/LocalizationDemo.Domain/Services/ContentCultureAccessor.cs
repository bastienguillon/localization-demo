using LocalizationDemo.Domain.Models;

namespace LocalizationDemo.Domain.Services;

public sealed class ContentCultureAccessor
{
    public required string ContentCulture { get; set; } = Models.ContentCulture.Default;
}
