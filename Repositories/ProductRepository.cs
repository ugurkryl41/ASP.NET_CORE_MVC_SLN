using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Product product) => Create(product);
        public void DeleteOneProduct(Product product) => Remove(product);
        public void UpdateOneProduct(Product product) => Update(product);
        public IQueryable<Product> GetAllProducts(bool trackChanges) => GetAll(trackChanges);
        public Product? GetOneProduct(int id, bool trackchanges) => FindByCondition(p => p.ProductId.Equals(id), trackchanges);
        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return GetAll(trackChanges).Where(p => p.ShowCase.Equals(true));
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context.Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice)
                .ToPaginate(p.PageNumber,p.PageSize);
        }
    }
}
