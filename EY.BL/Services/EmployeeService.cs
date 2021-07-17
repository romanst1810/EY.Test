using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EY.BL.Interfaces;
using EY.Core.Domain;
using EY.Core.Repository;

namespace EY.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepository;
        public EmployeeService(IEmployeeRepository empRepository)
        {
            this._empRepository = empRepository;
        }
        
        public async Task CreateAsync(Employee item)
        {
            await _empRepository.CreateAsync(item);
        }

        public async Task<IReadOnlyCollection<Employee>> FetchAsync()
        {
            var result = await _empRepository.FetchAsync();
            return result;
        }

        public async Task<IReadOnlyCollection<Employee>> FetchByDepartmentIdAsync(Guid? departmentId)
        {
            var result = await _empRepository.FetchByDepartmentIdAsync(departmentId);
            return result;
        }
    }
}
