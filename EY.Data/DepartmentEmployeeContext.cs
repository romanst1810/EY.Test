using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using EY.Core;
using EY.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EY.Data
{
    class DepartmentEmployeeContext : DbContext
    {
        private const string DefaultConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DepartmentEmployee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly string _connectionString;


        public DepartmentEmployeeContext(string connectionString = default)
        {
            this._connectionString = connectionString ?? DefaultConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employes { get; set; }
    }
}
