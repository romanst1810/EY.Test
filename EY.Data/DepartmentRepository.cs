using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EY.Core;
using EY.Core.Domain;
using EY.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace EY.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentRepository()
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

        public async Task CreateAsync(Department item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            using (var context = CreateContext())
            {
                context.Departments.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Department item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            using (var context = CreateContext())
            {
                Department d = await context.Departments.FirstOrDefaultAsync(x=>x.Id == item.Id);
                d.Description = item.Description;
                d.Name = item.Name;
                d.WorkStatus = item.WorkStatus;
                d.DateUpdate = DateTime.Now;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<Department>> FetchAsync()
        {
            using (var context = CreateContext())
            {
                return await context.Departments.ToArrayAsync();
            }
        }

        public async Task AddEmployeeAsync(Guid departmentId,Guid employeeId)
        {
            if (departmentId != Guid.Empty && employeeId != Guid.Empty && departmentId != null && employeeId != null)
                throw new ArgumentNullException(nameof(departmentId) + nameof(employeeId));
            using (var context = CreateContext())
            {
                Department dep = await context.Departments.FirstOrDefaultAsync(x=>x.Id == departmentId);
                Employee emp = await context.Employes.FirstOrDefaultAsync(x => x.Id == employeeId);
                if (dep != null && emp != null)
                {
                    dep.Employers.Add(emp);
                    emp.DepartmentId = dep.Id;
                    emp.Department = dep;
                    await context.SaveChangesAsync();
                }
                else throw new Exception("Department or Employee does not exists");
            }
        }

        public async Task RemoveEmployeeAsync(Guid departmentId, Guid employeeId)
        {
            if (departmentId != Guid.Empty && employeeId != Guid.Empty && departmentId != null && employeeId != null)
                throw new ArgumentNullException(nameof(departmentId) + nameof(employeeId));
            using (var context = CreateContext())
            {
                Department dep = await context.Departments.FirstOrDefaultAsync(x => x.Id == departmentId);
                Employee emp = await context.Employes.FirstOrDefaultAsync(x => x.Id == employeeId);
                if (dep != null && emp != null)
                {
                    dep.Employers.Remove(emp);
                    emp.DepartmentId = null;
                    emp.Department = null;
                    await context.SaveChangesAsync();
                }
                else throw new Exception("Department or Employee does not exists");
            }
        }

        private static DepartmentEmployeeContext CreateContext()
        {
            return new DepartmentEmployeeContext();
        }
    }
}
