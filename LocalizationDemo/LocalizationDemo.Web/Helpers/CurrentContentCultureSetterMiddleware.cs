using LocalizationDemo.Domain.Models;
using LocalizationDemo.Domain.Services;

namespace LocalizationDemo.Web.Helpers;

public sealed class CurrentContentCultureSetterMiddleware(RequestDelegate next)
{
    private const string CultureCodeQueryParam = "cultureCode";

    public async Task InvokeAsync(
        HttpContext context,
        ContentCultureAccessor cultureAccessor
    )
    {
        if (context.Request.Query.TryGetValue(CultureCodeQueryParam, out var cultureCode) &&
            ContentCulture.All.Contains(cultureCode.ToString()))
        {
            cultureAccessor.ContentCulture = cultureCode.ToString();
        }
        else
        {
            cultureAccessor.ContentCulture = ContentCulture.Default;
        }

        await next(context);
    }
}