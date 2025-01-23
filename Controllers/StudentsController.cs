using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}
