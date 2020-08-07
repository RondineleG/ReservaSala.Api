using EmployeeApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
