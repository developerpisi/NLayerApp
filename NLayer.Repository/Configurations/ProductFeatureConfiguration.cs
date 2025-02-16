using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations;

internal class ProductFeatureConfiguration:IEntityTypeConfiguration<ProductFeature>
{
    
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseMySqlIdentityColumn(); 
        builder.HasOne(x => x.Product).WithOne(x=>x.ProductFeature).HasForeignKey<ProductFeature>(x=>x.ProductId);
        builder.ToTable("ProductFeatures");

    }
}