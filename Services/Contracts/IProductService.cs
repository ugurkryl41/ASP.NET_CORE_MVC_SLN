﻿using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLastestProducts(int n,bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);        
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}
