using ReservaSala.Api.Data;

namespace ReservaSala.Api.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDataContext _context;

        public BaseRepository(AppDataContext context)
        {
            _context = context;
        }
    }
}