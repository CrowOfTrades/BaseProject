using BaseProject.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Application
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Guid> CreateOne(string Name, decimal Price, int Quantity);
        Task<bool> UpdateOne(Guid Id, string Name, decimal Price);
        Task<bool> UpdateQuantity(Guid Id, int Quantity);
        Task<bool> DeleteOne(Guid Id);

    }
}
