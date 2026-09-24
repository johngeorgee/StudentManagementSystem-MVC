using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class TraineeController : Controller
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IResultRepository _resultRepository;
    public TraineeController( ITraineeRepository traineeRepository, 
        IDepartmentRepository departmentRepository, IResultRepository resultRepository)
    {
        _traineeRepository = traineeRepository;
        _departmentRepository = departmentRepository;
        _resultRepository = resultRepository;
    }
    // GET
    public IActionResult Index(string search)
    {
        var trainees = _traineeRepository.GetTraineeDetails();
        if (!string.IsNullOrWhiteSpace(search))
        {
            trainees = trainees.Where(t => t.Name.Contains(search));
        }
    
        return View(trainees.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var trainee = _traineeRepository.GetTraineeDetails()
                     .FirstOrDefault(t => t.Id == id);
        return View(trainee);
    }

    public IActionResult Create()
    {
        ViewBag.Departments = new SelectList(
           _departmentRepository.GetAll(),
            "Id",
            "Name"
        );

        return View("Create");
    }
    public IActionResult Add(Trainee trainee)
    {
        if (trainee != null)
        {
            _traineeRepository.Add(trainee);
            _traineeRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(trainee);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        Trainee? trainee = _traineeRepository.GetById(id);
        EditTrainee? TraineeVM = new EditTrainee();
        TraineeVM.Id = trainee.Id;
        TraineeVM.Name = trainee.Name;
        TraineeVM.PhoneNumber = trainee.PhoneNumber;
        TraineeVM.Grade = trainee.Grade;
        TraineeVM.DepartmentId = trainee.DepartmentId;
        TraineeVM.CourseResults = _resultRepository.GetAll();
        TraineeVM.Department = _departmentRepository.GetAll();

        return View("Edit", TraineeVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditTrainee traineeVM)
    {
        if (ModelState.IsValid)
        {
            Trainee? Trainee = _traineeRepository.GetById(traineeVM.Id);
            Trainee.Id = traineeVM.Id;
            Trainee.Name = traineeVM.Name;
            Trainee.PhoneNumber = traineeVM.PhoneNumber;
            Trainee.Grade = traineeVM.Grade;
            Trainee.DepartmentId = traineeVM.DepartmentId;
            traineeVM.CourseResults = _resultRepository.GetAll();
            traineeVM.Department = _departmentRepository.GetAll();
          
            _traineeRepository.SaveChanges();

            return RedirectToAction("Index");

        }
        else
        {
            traineeVM.Department = _departmentRepository.GetAll();
            return View("Edit", traineeVM);
        }
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Trainee? trainee = _traineeRepository.GetById(id);

        if (trainee == null)
            return NotFound();
        
        _traineeRepository.Delete(trainee.Id);
        _traineeRepository.SaveChanges();

        return RedirectToAction("Index");
    }
}