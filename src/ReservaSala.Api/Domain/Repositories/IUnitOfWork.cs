using System.Threading.Tasks;

namespace ReservaSala.Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}