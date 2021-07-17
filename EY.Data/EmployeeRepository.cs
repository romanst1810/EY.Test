using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EY.Core;
using EY.Core.Domain;
using EY.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace EY.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
            try
            {
                var context = new DepartmentEmployeeContext();
                context.Database.Migrate(); // apply all migrations
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateAsync(Employee item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            using (var context = CreateContext())
            {
                context.Employes.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<Employee>> FetchAsync()
        {
            using (var context = CreateContext())
            {
                return await context.Employes.ToArrayAsync();
            }
        }
        public async Task<IReadOnlyCollection<Employee>> FetchByDepartmentIdAsync(Guid? departmentId)
        {
            using (var context = CreateContext())
            {
                return await context.Employes.Where(x=>x.DepartmentId == departmentId).ToArrayAsync();
            }
        }

        private static DepartmentEmployeeContext CreateContext()
        {
            return new DepartmentEmployeeContext();
        }
    }
}
