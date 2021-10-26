using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // we can access the properties that are present inside the Product.cs
            // from here 

            // eg = we need the Id property should be definatly required i.e. not null
            builder.Property(p => p.Id).IsRequired();

            // we also need name propery as compalsery i.e. not null
            // we also set the max length to a string property 
            builder.Property(p => p.Name).IsRequired()
                                         .HasMaxLength(100); // max len = 100
            
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.PictureUrl).IsRequired();
            
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)"); // 18 0's and 2 decimal values 

            // set the foreignkey ( this was already set by dotnet by default )
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(P => P.ProductBrandId);

            // set the foreignkey ( this was already set by dotnet by default )
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);

        }
    }
}