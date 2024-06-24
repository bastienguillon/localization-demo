using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class I18nRangeFormElementConfiguration : IEntityTypeConfiguration<I18nRangeFormElementStructure>
{
    public void Configure(EntityTypeBuilder<I18nRangeFormElementStructure> builder)
    {
        builder.ToTable(nameof(I18nRangeFormElementStructure));
        builder.HasKey(r => r.Id);
    }
}