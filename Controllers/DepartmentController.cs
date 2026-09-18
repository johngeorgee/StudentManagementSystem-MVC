using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class DepartmentController : Controller
{
    private readonly AppDbContext _context;

    public DepartmentController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index(string search)
    {
        var departments = _context.Departments.AsQueryable()
            .Include(c=> c.Courses)
            .Include(t => t.Trainees)
            .Include(t => t.Instructors);
        if (!string.IsNullOrWhiteSpace(search))
        {
            departments = departments.Where(d => d.Name.Contains(search))
                .Include(c=> c.Courses)
                .Include(t => t.Trainees)
                .Include(t => t.Instructors);
        }
        return View(departments.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var department = _context.Departments
            .Include(c=> c.Courses)
            .Include(t => t.Trainees)
            .Include(t => t.Instructors)
            .FirstOrDefault(d => d.Id == id);
        return View(department);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _context.Courses.ToList(),
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
    public IActionResult Add(Department dept)
    {
        if (dept != null)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(dept);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        var Dept = _context.Departments 
            .FirstOrDefault(d => d.Id == id);
        List <Course> courses= _context.Courses.ToList();
        List <Trainee> trainees= _context.Trainees.ToList();
        List <Instructor> instructors= _context.Instructors.ToList();
        EditDepartment DeptVM = new EditDepartment();
        DeptVM.Id = Dept.Id;
        DeptVM.Name = Dept.Name;
        DeptVM.ManagerName = Dept.ManagerName;


        return View("Edit", DeptVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditDepartment Dept)
    {
        if (ModelState.IsValid)
        {
            var DeptData = _context.Departments 
                .FirstOrDefault(d => d.Id == Dept.Id);
            DeptData.Id = Dept.Id;
            DeptData.Name = Dept.Name;
            DeptData.ManagerName = Dept.ManagerName;
            

            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        else
        {
            return View("Edit", Dept);
        }
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Department? department = _context.Departments
            .FirstOrDefault(i => i.Id == id);

        if (department == null)
            return NotFound();

        department.IsDeleted = true;
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}