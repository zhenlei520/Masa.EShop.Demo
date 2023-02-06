namespace Masa.EShop.Service.Catalog.Infrastructure.EntityConfigurations;

public class CatalogTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable(nameof(CatalogType));
        
        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id)
           .IsRequired();

        builder.Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}