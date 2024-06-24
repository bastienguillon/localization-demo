using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class I18nListFormElementConfiguration: IEntityTypeConfiguration<I18nListFormElementStructure>
{
    public void Configure(EntityTypeBuilder<I18nListFormElementStructure> builder)
    {
        builder.ToTable(nameof(I18nListFormElementStructure));
        builder.HasKey(l => l.Id);
    }
}