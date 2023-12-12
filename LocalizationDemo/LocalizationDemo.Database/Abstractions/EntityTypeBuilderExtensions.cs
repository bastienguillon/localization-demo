using LocalizationDemo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalizationDemo.Database.Abstractions;

public static class EntityTypeBuilderExtensions
{
    public static OwnedNavigationBuilder<TOwner, TTranslation> DeclareTranslatable<TTranslation, TOwner>(
        this OwnedNavigationBuilder<TOwner, TTranslation> builder
    )
        where TTranslation : class, ITranslation
        where TOwner : class
    {
        builder
            .Property(translation => translation.CultureCode)
            .IsRequired()
            .HasColumnName("CultureCode")
            .HasMaxLength(16);

        builder
            .Property(translation => translation.IsDefault)
            .IsRequired()
            .HasColumnName("IsDefault")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        return builder;
    }
}