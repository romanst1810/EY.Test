using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EY.Core.Domain;

namespace EY.BL.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee item);
        Task<IReadOnlyCollection<Employee>> FetchAsync();
        Task<IReadOnlyCollection<Employee>> FetchByDepartmentIdAsync(Guid? departmentId);
    }
}
