using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class RangeFormElementStructureConfiguration : IEntityTypeConfiguration<RangeFormElementStructure>
{
    public void Configure(EntityTypeBuilder<RangeFormElementStructure> builder)
    {
        builder.HasMany(r => r.Translations)
            .WithOne()
            .HasForeignKey(t => t.FormElementId);
    }
}