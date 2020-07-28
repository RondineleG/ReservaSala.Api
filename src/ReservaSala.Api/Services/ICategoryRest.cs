using Refit;
using ReservaSala.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Services
{
    public interface ICategoryRest
    {
        [Get("/api/democrud")]
        Task<IEnumerable<Category>> GetAsync();

        [Get("/api/democrud/{id}")]
        Task<Category> GetAsync(int id);

        [Post("/api/democrud/create")]
        Task CreateAsync([Body] Category country);

        [Put("/api/democrud/update/{id}")]
        Task ReplaceAsync(int id, [Body] Category country);

        [Patch("/api/democrud/update/{id}/description")]
        Task UpdateAsync(int id, [Body] string description);

        [Delete("/api/democrud/delete/{id}")]
        Task DeleteAsync(int id);
    }
}
