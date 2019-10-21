using System.Linq;

namespace DependencyInjection.Models
{
    public class ProductTotalizer
    {
        public IRepository Repository { get; set; }

        public ProductTotalizer(IRepository repo) => Repository = repo;

        public decimal Total => Repository.Products.Sum(p => p.Price);
    }
}
