using EmployeeApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<Employee> Delete(int id);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<Employee> GetByEmail(string email);
    }
}
