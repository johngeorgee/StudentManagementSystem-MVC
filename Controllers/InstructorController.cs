using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class InstructorController : Controller
{
    private readonly AppDbContext _context;

    public InstructorController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index(string search)
    {
        var instructors = _context.Instructors.AsQueryable()
            .Include(d => d.Department)
            .Include(c => c.Course);
          
        if (!string.IsNullOrWhiteSpace(search))
        {
            instructors = instructors.Where(i => i.Name.Contains(search))
                .Include(d => d.Department)
                .Include(c => c.Course);
                
        }
        return View(instructors.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var instructor = _context.Instructors
            .Include(d=> d.Department)
            .Include(c => c.Course)
            .FirstOrDefault(ins => ins.Id == id);
        return View(instructor);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _context.Courses.ToList(),
            "Id",
            "Name"
        );
        ViewBag.Departments = new SelectList(
            _context.Departments.ToList(),
            "Id",
            "Name"
        );
        return View("Create");
    }
    public IActionResult Add(Instructor instructor)
    {
        if (instructor != null)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(instructor);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        var Instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
        List <Course> courses= _context.Courses.ToList();
        List <Department> departments= _context.Departments.ToList();
        EditInstructor InstructorVM = new EditInstructor();
        InstructorVM.Id = Instructor.Id;
        InstructorVM.Name = Instructor.Name;
        InstructorVM.Salary = Instructor.Salary;
        InstructorVM.Email = Instructor.Email;
        InstructorVM.CourseId = Instructor.CourseId;
        InstructorVM.DepartmentId = Instructor.DepartmentId;
        InstructorVM.Department = departments;
        InstructorVM.Course = courses;
       

        return View("Edit", InstructorVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditInstructor instructor)
    {
        if (ModelState.IsValid)
        {
            var InsData = _context.Instructors.FirstOrDefault(ins => ins.Id == instructor.Id);
            InsData.Id = instructor.Id;
            InsData.Name = instructor.Name;
            InsData.Salary = instructor.Salary;
            InsData.Email = instructor.Email;
            InsData.DepartmentId = instructor.DepartmentId;
            InsData.CourseId = instructor.CourseId;
          
            instructor.Course = _context.Courses.ToList();
            instructor.Department = _context.Departments.ToList();
          
            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        else
        {
            return View("Edit", instructor);
        }
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Instructor? instructor = _context.Instructors
            .FirstOrDefault(i => i.Id == id);

        if (instructor == null)
            return NotFound();

        _context.Instructors.Remove(instructor);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}