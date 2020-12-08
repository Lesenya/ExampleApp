
using System.Linq;

namespace ExampleApp.Models
{
    public interface IRepository
    {
        public IQueryable<Product> Products { get;}
    }
}
