using ReservaSala.Api.Data;
using ReservaSala.Api.Domain.Repositories;
using System.Threading.Tasks;

namespace ReservaSala.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _context;

        public UnitOfWork(AppDataContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}