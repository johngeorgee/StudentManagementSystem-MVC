using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index(string search)
    {
        var courses = _context.Courses.AsQueryable()
            .Include(r => r.CourseResults)
            .ThenInclude(t => t.Trainee)
            .Include(t => t.Instructors)
            .Include(d => d.Department);
        if (!string.IsNullOrWhiteSpace(search))
        {
            courses = courses.Where(c => c.Name.Contains(search)).Include(r => r.CourseResults)
                .ThenInclude(t => t.Trainee)
                .Include(t => t.Instructors)
                .Include(d => d.Department);;
        }
        return View(courses.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var course = _context.Courses.Include(r => r.CourseResults)
            .ThenInclude(t => t.Trainee)
            .Include(t => t.Instructors)
            .Include(d => d.Department)
            .FirstOrDefault(c => c.Id == id);
        return View(course);
    }
    public IActionResult Create()
    {
        ViewBag.Departments = new SelectList(
            _context.Departments.ToList(),
            "Id",
            "Name"
        );
        ViewBag.Instructors = new SelectList(
            _context.Instructors.ToList(),
            "Id",
            "Name"
        );
        return View("Create");
    }

    public IActionResult Add(Course course)
    {
        if (course != null)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(course);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        Course? Course = _context.Courses.FirstOrDefault(c => c.Id == id);
        if (Course == null) return NotFound();
        EditCourse CourseVM = new EditCourse();
        CourseVM.Id = Course.Id;
        CourseVM.Name = Course.Name;
        CourseVM.Degree = Course.Degree;
        CourseVM.DepartmentId = Course.DepartmentId;
        CourseVM.Department = _context.Departments.ToList();


        return View("Edit", CourseVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditCourse course)
    {
        if (!ModelState.IsValid)
        {
            foreach (var item in ModelState)
            {
                Console.WriteLine($"KEY: {item.Key}");

                foreach (var error in item.Value.Errors)
                {
                    Console.WriteLine($"ERROR: {error.ErrorMessage}");
                }
            }
            course.Department = _context.Departments.ToList();

            return View("Edit", course);
        }

        Course? courseData = _context.Courses
            .FirstOrDefault(c => c.Id == course.Id);

        if (courseData == null)
            return NotFound();

        courseData.Name = course.Name;
        courseData.Degree = course.Degree;
        courseData.DepartmentId = course.DepartmentId;
        _context.SaveChanges();

        return RedirectToAction("Index");
        
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Course? course = _context.Courses
            .FirstOrDefault(i => i.Id == id);

        if (course == null)
            return NotFound();

        _context.Courses.Remove(course);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}