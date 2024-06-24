using LocalizationDemo.Domain.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Storage.Configurations.Forms;

public class FormElementConfiguration : IEntityTypeConfiguration<FormElement>
{
    public void Configure(EntityTypeBuilder<FormElement> builder)
    {
        builder.ToTable(nameof(FormElement));

        builder.HasKey(f => f.Id);
        
        builder.HasDiscriminator(f => f.FormElementDiscriminator)
            .HasValue(typeof(FeedbackFormElement), "feedback")
            .HasValue(typeof(ReviewFormElement), "review");
        
        builder.HasOne(f => f.FormElementStructure)
            .WithOne()
            .HasForeignKey<FormElementStructure>(formElementStructure => formElementStructure.Id)
            .IsRequired();

        builder.HasMany(f => f.Translations)
            .WithOne()
            .HasForeignKey(i18n => i18n.FormElementId);
    }
}