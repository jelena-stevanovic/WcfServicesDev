using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    class EmployeeService : IEmployeeService
    {
        private NORTHWNDEntities nwe = new NORTHWNDEntities();

        public List<EmployeeDto> GetAllEmployees()
        {
            return nwe.Employees.Select(
                e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title,
                    BirthDate = e.BirthDate ?? DateTime.Now
                }).ToList();
        }

        public void AddEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee
            {
                EmployeeID = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                BirthDate = employee.BirthDate
            };
            nwe.Employees.Add(emp);
            nwe.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = nwe.Employees.FirstOrDefault(e => e.EmployeeID == id);
            nwe.Employees.Remove(employee);
            nwe.SaveChanges();
        }


        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = nwe.Employees.FirstOrDefault(e => e.EmployeeID == id);
            return employee != null ? new EmployeeDto
            {
                EmployeeId = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                BirthDate = employee.BirthDate ?? DateTime.Now
            } : null;
        }

        public void UpdateEmployee(EmployeeDto employee)
        {
            var emp = nwe.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeId);
            emp.EmployeeID = employee.EmployeeId;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Title = employee.Title;
            emp.BirthDate = employee.BirthDate;

            nwe.SaveChanges();
        }

    }
}
