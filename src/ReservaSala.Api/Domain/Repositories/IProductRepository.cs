using ReservaSala.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        void Update(Product product);
        void Remove(Product product);
    }
}