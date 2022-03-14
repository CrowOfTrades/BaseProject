using BaseProject.Model;
using BaseProject.Model.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.Repository.Cache
{
    public class ProdutoRepository : BaseRepositoryJson<Product>, IProdutoRepository
    {
        public ProdutoRepository() : base()
        {
            CACHE_KEY = Product.KeyName;
        }

        public IList<Product> GetAll()
        {
            var products = Get();
            return products;
        }

        public bool CreateOne(Product product)
        {
            Save(product);
            return true;
        }

        public bool UpdateOne(Guid id, string name, decimal price)
        {
            var products = GetAll();

            var product = products.Where(w => w.Id == id).FirstOrDefault();
            if (product is null) return false;

            product.Price = price;
            product.Name = name;

            Save(products, product);
            return true;
        }

        public bool UpdateQuantity(Guid id, int quantity)
        {
            var products = GetAll();

            var product = products.Where(w => w.Id == id).FirstOrDefault();
            if (product is null) return false;

            product.Quantity = quantity;

            Save(products, product);
            return true;
        }

        public bool DeleteOne(Guid id)
        {
            var products = GetAll();

            products = products.Where(w => w.Id != id).ToList();

            Save(products);
            return true;
        }
    }
}
