using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityProcedureCF
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures
                (p => p.Insert(x => x.HasName("EmployeeInsert")
                .Parameter(a => a.name, "EmployeeName")
                .Parameter(a => a.gender, "EmployeeGender")
                .Parameter(a => a.salary, "EmployeeSalary"))
                .Delete(y=> y.HasName("EmployeeDelete"))
                .Update(z=> z.HasName("EmployeeUpdate")));
            base.OnModelCreating(modelBuilder);
        }
    }
}