using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseMySqlIdentityColumn(); 
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.ToTable("Categories");
    }
}