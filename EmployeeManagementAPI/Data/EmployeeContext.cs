using employeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeManagementAPI.Data
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}




