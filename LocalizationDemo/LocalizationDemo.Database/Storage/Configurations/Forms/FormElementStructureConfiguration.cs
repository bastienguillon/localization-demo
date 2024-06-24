using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class FormElementStructureConfiguration : IEntityTypeConfiguration<FormElementStructure>
{
    public void Configure(EntityTypeBuilder<FormElementStructure> builder)
    {
        builder.ToTable(nameof(FormElement));
        builder
            .HasDiscriminator(fs => fs.FormElementStructureDiscriminator)
            .HasValue(typeof(RangeFormElementStructure), "range")
            .HasValue(typeof(ListFormElementStructure), "list");
    }
}