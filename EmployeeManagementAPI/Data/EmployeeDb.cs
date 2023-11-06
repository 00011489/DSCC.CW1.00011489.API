using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class EmployeeDb: DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
