using BaseProject.Model;
using BaseProject.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Application
{
    public class ProductService : IProductService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProductService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IList<Product>> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public async Task<Guid> CreateOne(string name, decimal price, int quantity)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Quantity = quantity,
                CreatedDate = DateTime.Now
            };
            _produtoRepository.CreateOne(product);
            return product.Id;
        }

        public async Task<bool> UpdateOne(Guid id, string name, decimal price)
        {
            return _produtoRepository.UpdateOne(id, name, price);
        }

        public async Task<bool> UpdateQuantity(Guid id, int quantity)
        {
            return _produtoRepository.UpdateQuantity(id, quantity);
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            return _produtoRepository.DeleteOne(id);
        }
    }
}
