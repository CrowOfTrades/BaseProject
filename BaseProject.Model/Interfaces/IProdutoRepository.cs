using System;
using System.Collections.Generic;

namespace BaseProject.Model.Interfaces
{
    public interface IProdutoRepository
    {
        IList<Product> GetAll();
        bool CreateOne(Product product);
        bool UpdateOne(Guid id, string name, decimal price);
        bool UpdateQuantity(Guid id, int quantity);
        bool DeleteOne(Guid id);

    }
}
