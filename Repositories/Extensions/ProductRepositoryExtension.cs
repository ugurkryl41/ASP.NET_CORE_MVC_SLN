using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
        {
            if (categoryId == null)
            {
                return products;
            }
            else
            {
                return products.Where(prd => prd.CategoryId.Equals(categoryId));
            }
        }

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, String? SearchTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                return products;
            else
                return products.Where(prd => prd.ProductName.ToLower().Contains(SearchTerm.ToLower()));
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int minPrice, int MaxPrice,bool IsValidPrice)
        {
            if (IsValidPrice)
                return products.Where(prd => prd.ProductPrice >= minPrice && prd.ProductPrice <= MaxPrice);
            return products;
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products.Skip((pageNumber-1)*pageSize)
                .Take(pageSize);
        }
    }
}
