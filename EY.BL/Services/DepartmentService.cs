using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EY.BL.Interfaces;
using EY.Core.Domain;
using EY.Core.Repository;

namespace EY.BL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _depRepository;
        public DepartmentService(IDepartmentRepository depRepository)
        {
            this._depRepository = depRepository;
        }

        public async Task CreateAsync(Department item)
        {
            await _depRepository.CreateAsync(item);
        }
        public async Task UpdateAsync(Department item)
        {
            await _depRepository.UpdateAsync(item);
        }

        public async Task<IReadOnlyCollection<Department>> FetchAsync()
        {
            var result = await _depRepository.FetchAsync();
            return result;
        }

        public async Task AddEmployeeAsync(Guid departmentId, Guid employeeId)
        {
            await _depRepository.AddEmployeeAsync(departmentId, employeeId);
        }

        public async Task RemoveEmployeeAsync(Guid departmentId, Guid employeeId)
        {
            await _depRepository.RemoveEmployeeAsync(departmentId, employeeId);
        }
    }
}
