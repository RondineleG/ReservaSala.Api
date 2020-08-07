using ReservaSala.Api.Data;
using EmployeeApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSala.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await appDbContext.Employees
                .Include(x=>x.Department)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee> Add(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Employee> Update(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;


                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<Employee> Delete(int id)
        {
            var result = await appDbContext.Employees
             .FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(x=>x.Email == email);
            
        }
                

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {

            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
