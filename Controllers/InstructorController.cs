using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class InstructorController : Controller
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ICourseRepository _courseRepository;

    public InstructorController( IInstructorRepository instructorRepository,
        IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
    {
        _instructorRepository = instructorRepository;
        _departmentRepository = departmentRepository;
        _courseRepository = courseRepository;
    }
    // GET
    public IActionResult Index(string search)
    {
        var instructors = _instructorRepository.GetInstructorDetails();
          
        if (!string.IsNullOrWhiteSpace(search))
        {
            instructors = instructors.Where(i => i.Name.Contains(search));

        }
        return View(instructors.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var instructor = _instructorRepository.GetInstructorDetails()
            .FirstOrDefault(i => i.Id == id);
        return View(instructor);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _courseRepository.GetAll(),
            "Id",
            "Name"
        );
        ViewBag.Departments = new SelectList(
            _departmentRepository.GetAll(),
            "Id",
            "Name"
        );
        return View("Create");
    }
    public IActionResult Add(Instructor instructor)
    {
        if (instructor != null)
        {
            _instructorRepository.Add(instructor);
            _instructorRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(instructor);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        var Instructor =_instructorRepository.GetById(id);
        List<Course> courses = _courseRepository.GetAll();
        List<Department> departments = _departmentRepository.GetAll();
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
            var InsData = _instructorRepository.GetById(instructor.Id);
            InsData.Id = instructor.Id;
            InsData.Name = instructor.Name;
            InsData.Salary = instructor.Salary;
            InsData.Email = instructor.Email;
            InsData.DepartmentId = instructor.DepartmentId;
            InsData.CourseId = instructor.CourseId;
            instructor.Course = _courseRepository.GetAll();
            instructor.Department = _departmentRepository.GetAll();
            
          
            
            _instructorRepository.SaveChanges();
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
        Instructor? instructor = _instructorRepository.GetById(id);

        if (instructor == null)
            return NotFound();
        
        _instructorRepository.Delete(instructor.Id);
        _instructorRepository.SaveChanges();

        return RedirectToAction("Index");
    }
}