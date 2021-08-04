using ReservaSala.Api.Domain.Models;
using ReservaSala.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}