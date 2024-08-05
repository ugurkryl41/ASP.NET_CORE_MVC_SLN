using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            /* Product product = new Product()
             {
                  ProductName = productDto.ProductName,
                  ProductPrice = productDto.ProductPrice,
                  CategoryId = productDto.CategoryId,
             };*/

            Product product = _mapper.Map<Product>(productDto);

            _manager.Product.CreateOneProduct(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product? product = GetOneProduct(id, false); // ?? new Product();

            if (product != null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }

        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _manager.Product
                .GetAll(trackChanges)
                .OrderByDescending(prd => prd.ProductId)
                .Take(n);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);

            if (product is null)
            {
                throw new Exception("Product Not Found");
            }

            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);

            return _mapper.Map<ProductDtoForUpdate>(product);
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
           return _manager.Product.GetShowcaseProducts(trackChanges);
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            /*
            //Repository'e kadar gitmeye gerek kalmadı EF zaten tracking yapıyor.
            var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            entity.ProductName = productDto.ProductName;
            entity.ProductPrice = productDto.ProductPrice;
            entity.CategoryId = productDto.CategoryId;
            */

            // yukarıdaki entity referansı burada değişeceği için izleme yapmayacaktır. ve Aşağıda UpdateOneProduct Metot ürettik
            var entity = _mapper.Map<Product>(productDto);             
            _manager.Product.UpdateOneProduct(entity);            
            _manager.Save();            

        }
    }
}
