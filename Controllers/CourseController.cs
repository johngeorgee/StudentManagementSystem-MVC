using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Project.Data;
using Project.Interfaces;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class CourseController : Controller
{
    private readonly ICourseRepository _courseRepository;
    private readonly IDepartmentRepository _deptRepository;
    private readonly  IInstructorRepository _instructorRepository;

    public CourseController(ICourseRepository  courseRepository,
        IDepartmentRepository deptRepository, IInstructorRepository instructorRepository)
    {
        _courseRepository = courseRepository;
        _instructorRepository  = instructorRepository;
        _deptRepository = deptRepository;

    }
    // GET
    public IActionResult Index(string search)
    {

        var courses = _courseRepository.GetCourseDetails();
        if (!string.IsNullOrWhiteSpace(search))
        {
            courses = courses.Where(c => c.Name.Contains(search));
        }

        return View(courses.ToList());

    }
    public IActionResult ShowById(int id)
    {
        var course = _courseRepository.GetCourseDetails()
            .FirstOrDefault(c => c.Id == id);
        return View(course);
    }
    public IActionResult Create()
    {
        ViewBag.Departments = new SelectList(
            _deptRepository.GetAll(),
            "Id",
            "Name"
        );
        ViewBag.Instructors = new SelectList(
            _instructorRepository.GetAll(),
            "Id",
            "Name"
        );
        return View("Create");
    }

    public IActionResult Add(Course course)
    {
        if (course != null)
        {

            _courseRepository.Add(course);
            _courseRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(course);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        Course? course = _courseRepository.GetById(id);
        if (course == null) return NotFound();
        EditCourse CourseVM = new EditCourse();
        CourseVM.Id = course.Id;
        CourseVM.Name = course.Name;
        CourseVM.Degree = course.Degree;
        CourseVM.DepartmentId = course.DepartmentId;
        CourseVM.Department = _deptRepository.GetAll();


        return View("Edit", CourseVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditCourse course)
    {
        if (!ModelState.IsValid)
        {
           course.Department = _deptRepository.GetAll();

            return View("Edit", course);
        }
        Course? courseData = _courseRepository.GetById(course.Id);
        if (courseData == null)
            return NotFound();

        courseData.Name = course.Name;
        courseData.Degree = course.Degree;
        courseData.DepartmentId = course.DepartmentId;
        _courseRepository.SaveChanges();
        return RedirectToAction("Index");
        
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Course? course = _courseRepository.GetById(id);

        if (course == null)
            return NotFound();

        _courseRepository.Delete(course.Id);
        _courseRepository.SaveChanges();

        return RedirectToAction("Index");
    }
}