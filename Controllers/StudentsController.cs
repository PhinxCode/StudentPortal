using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: StudentsController
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddStudentViewModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Subscribed = model.Subscribed,
            };

            Console.WriteLine(
                $"parametros: FirstName={student.FirstName}, LastName={student.LastName}, Phone={student.Phone}, Email={student.Email}, Address={student.Address}, DateOfBirth={student.DateOfBirth}, Subscribed={student.Subscribed}"
            );

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            // return dbContext.Students.AddAsync();
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }
    }
}
