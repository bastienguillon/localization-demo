using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class I18nFormElementConfiguration : IEntityTypeConfiguration<I18nFormElement>
{
    public void Configure(EntityTypeBuilder<I18nFormElement> builder)
    {
        builder.ToTable(nameof(I18nFormElement));
        builder.HasKey(i18n => i18n.Id);
    }
}
