using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.ProductId);  // PK

            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductPrice).IsRequired();

            builder.HasData(
                    new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "PC1", ProductPrice = 1000, ShowCase = true },
                    new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "PC2", ProductPrice = 2000, ShowCase = false },
                    new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "PC3", ProductPrice = 3000, ShowCase = true },
                    new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "PC4", ProductPrice = 4000, ShowCase = false },
                    new Product() { ProductId = 5, CategoryId = 1, ImageUrl = "/images/5.jpg", ProductName = "History", ProductPrice = 55, ShowCase = true },
                    new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "Hamlet", ProductPrice = 63, ShowCase = false });
        }
    }
}
