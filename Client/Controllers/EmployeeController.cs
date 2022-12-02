using Client.EmployeeServiceReference;
using Client.Models;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        
        EmployeeServiceReference.EmployeeServiceClient emp = new EmployeeServiceReference.EmployeeServiceClient();


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    BirthDate = employee.BirthDate
                };
                emp.AddEmployee(employeeDto);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeDto employeeDto = emp.GetEmployeeById(id);
            EmployeeViewModel employee = new EmployeeViewModel
            {
                EmployeeId = employeeDto.EmployeeId,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Title = employeeDto.Title,
                BirthDate = employeeDto.BirthDate
            };
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    BirthDate = employee.BirthDate
                };
                emp.UpdateEmployee(employeeDto);
                return RedirectToAction("Index", "Home");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            emp.DeleteEmployee(id);
            return RedirectToAction("Index", "Home");
        }
    }
}