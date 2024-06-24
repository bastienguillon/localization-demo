using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class ListFormElementStructureConfiguration : IEntityTypeConfiguration<ListFormElementStructure>
{
    public void Configure(EntityTypeBuilder<ListFormElementStructure> builder)
    {
        builder.HasMany(r => r.Translations)
            .WithOne()
            .HasForeignKey(t => t.FormElementId);
    }
}