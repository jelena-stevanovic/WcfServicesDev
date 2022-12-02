using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        EmployeeServiceReference.EmployeeServiceClient emp = new EmployeeServiceReference.EmployeeServiceClient();

        public ActionResult Index()
        {
            var employees = emp.GetAllEmployees();

            return View(employees);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}