using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds;

public class ProductSeed:IEntityTypeConfiguration<Product>
{
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product { Id = 1,CategoryId = 1,Name = "Kalem" ,Price = 100,Stock = 20, CreatedDate = DateTime.UtcNow},
            new Product { Id = 2,CategoryId = 2,Name = "Kitap" ,Price = 100,Stock = 20, CreatedDate = DateTime.UtcNow},
            new Product { Id = 3,CategoryId = 3,Name = "Defter" ,Price = 100,Stock = 20, CreatedDate = DateTime.UtcNow}
        );   
    }
}