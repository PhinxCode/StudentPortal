using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public StudentsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddStudentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model); // Si hay errores, mostrar el formulario con los mensajes de validación
        }

        var student = new Student
        {
            FirstName = CapitalizeFirstLetter(model.FirstName),
            LastName = CapitalizeFirstLetter(model.LastName),
            Phone = model.Phone,
            Email = model.Email?.ToLower(),
            Address = CapitalizeFirstLetter(model.Address),
            Subscribed = model.Subscribed,
        };

        await dbContext.Students.AddAsync(student);
        await dbContext.SaveChangesAsync();

        ModelState.Clear(); // Limpia el formulario después de enviar los datos
        TempData["SuccessMessage"] = "Student added successfully!";

        return View(); // Retorna la vista vacía después de limpiar el formulario
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var students = await dbContext.Students.ToListAsync();
        return View(students);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var student = await dbContext.Students.FindAsync(id);

        return View("Edit", student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Student model)
    {
        var student = await dbContext.Students.FindAsync(model.Id);

        if (student is not null)
        {
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Phone = model.Phone;
            student.Email = model.Email;
            student.Subscribed = model.Subscribed;

            await dbContext.SaveChangesAsync();
        }

        return RedirectToAction("List", "Students");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var student = await dbContext.Students.FindAsync(id);

        if (student is not null)
        {
            dbContext.Students.Remove(student); // Eliminar el objeto obtenido desde la BD
            await dbContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Student deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Student not found!";
        }

        return RedirectToAction("List", "Students");
    }

    /**** funcion capitalizar ****/
    private string? CapitalizeFirstLetter(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return value;

        return char.ToUpper(value[0]) + value.Substring(1).ToLower();
    }
}
