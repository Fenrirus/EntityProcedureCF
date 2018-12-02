using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityProcedureCF
{
    public class EmployeeRepository
    {
        EmployeeDbContext employeeDbContext = new EmployeeDbContext();
        public List<Employee> GetEmployee(Employee employee)
        {
            return employeeDbContext.Employees.ToList();
        }
        public void InsertEmployee(Employee employee)
        {
            employeeDbContext.Employees.Add(employee);
            employeeDbContext.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            Employee employeeToUpdate = employeeDbContext.Employees.SingleOrDefault(x => x.ID == employee.ID);
            employeeToUpdate.name = employee.name;
            employeeToUpdate.gender = employee.gender;
            employeeToUpdate.salary = employee.salary;
            employeeDbContext.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            Employee employeeToDelete = employeeDbContext.Employees.SingleOrDefault(x => x.ID == employee.ID);
            employeeDbContext.Employees.Remove(employeeToDelete);
            employeeDbContext.SaveChanges();
        }
    }
}