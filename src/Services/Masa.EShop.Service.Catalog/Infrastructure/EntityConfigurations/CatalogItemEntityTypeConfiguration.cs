using Masa.EShop.Service.Catalog.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Masa.EShop.Service.Catalog.Infrastructure.EntityConfigurations;

public class CatalogItemEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("Catalog");

        builder.Property(ci => ci.Id)
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(ci => ci.Price)
            .IsRequired(true);

        builder.Property(ci => ci.PictureFileName)
            .IsRequired(false);

        builder
            .Property<Guid>("_catalogBrandId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CatalogBrandId")
            .IsRequired();
        
        builder
            .Property<int>("_catalogTypeId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CatalogTypeId")
            .IsRequired();
        
        builder.HasOne(ci => ci.CatalogBrand)
            .WithMany()
            .HasForeignKey("_catalogBrandId");
        
        builder.HasOne(ci => ci.CatalogType)
            .WithMany()
            .HasForeignKey("_catalogTypeId");
    }
}