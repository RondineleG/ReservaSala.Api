using ReservaSala.Api.Data;
using ReservaSala.Api.Domain.Repositories;
using System.Threading.Tasks;

namespace ReservaSala.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}