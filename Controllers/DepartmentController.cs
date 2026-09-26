using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ITraineeRepository  _traineeRepository;

    public DepartmentController( IDepartmentRepository departmentRepository,
        IInstructorRepository instructorRepository,  ICourseRepository courseRepository, 
        ITraineeRepository traineeRepository)
    {

        _departmentRepository = departmentRepository;
        _instructorRepository = instructorRepository;
        _courseRepository = courseRepository;
        _traineeRepository = traineeRepository;
    }
    // GET
    public IActionResult Index(string search)
    {
        var departments = _departmentRepository.GetDepartmentDetails();
        if (!string.IsNullOrWhiteSpace(search))
        {
            departments = departments.Where(d => d.Name.Contains(search));

        }
        return View(departments.ToList());
    }
    public IActionResult ShowById(int id)
    {

        var department = _departmentRepository.GetDepartmentDetails()
            .FirstOrDefault(d => d.Id == id);
        return View(department);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _courseRepository.GetAll(),
            "Id",
            "Name"
        );
        ViewBag.Instructors = new SelectList(
            _courseRepository.GetAll(),
            "Id",
            "Name"
        );
        return View("Create");
    }
    public IActionResult Add(Department dept)
    {
        if (dept != null)
        {
            _departmentRepository.Add(dept);
            _departmentRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(dept);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        var Dept = _departmentRepository.GetById(id);
       
        List <Course> courses= _courseRepository.GetAll();
        List <Trainee> trainees= _traineeRepository.GetAll();
        List <Instructor> instructors= _instructorRepository.GetAll();
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
           
            var DeptData = _departmentRepository.GetById(Dept.Id);
            DeptData.Id = Dept.Id;
            DeptData.Name = Dept.Name;
            DeptData.ManagerName = Dept.ManagerName;
            

            
           _departmentRepository.SaveChanges();
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
       
        Department? department = _departmentRepository.GetById(id);

        if (department == null)
            return NotFound();

        department.IsDeleted = true;
       _departmentRepository.SaveChanges();

        return RedirectToAction("Index");
    }
}