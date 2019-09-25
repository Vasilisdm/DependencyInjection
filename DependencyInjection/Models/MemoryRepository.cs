using System;
using System.Collections.Generic;

namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        public Product this[string name] => throw new NotImplementedException();

        public IEnumerable<Product> Products => throw new NotImplementedException();

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
