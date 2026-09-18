using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class TraineeController : Controller
{
    private readonly AppDbContext _context;

    public TraineeController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index(string search)
    {
        var trainees = _context.Trainees.AsQueryable()
            .Include(c => c.CourseResults)
            .Include(d => d.Department);
        if (!string.IsNullOrWhiteSpace(search))
        {
            trainees = trainees.Where(t => t.Name.Contains(search))
                .Include(c => c.CourseResults)
                .Include(d => d.Department);
        }
    
        return View(trainees.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var trainee = _context.Trainees
            .Include(c => c.CourseResults)
            .Include(d=>d.Department)
            .FirstOrDefault(t => t.Id == id);
        return View(trainee);
    }

    public IActionResult Create()
    {
        ViewBag.Departments = new SelectList(
            _context.Departments.ToList(),
            "Id",
            "Name"
        );

        return View("Create");
    }
    public IActionResult Add(Trainee trainee)
    {
        if (trainee != null)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(trainee);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        Trainee Trainee = _context.Trainees.FirstOrDefault(t => t.Id == id);
        EditTrainee TraineeVM = new EditTrainee();
        TraineeVM.Id = Trainee.Id;
        TraineeVM.Name = Trainee.Name;
        TraineeVM.PhoneNumber = Trainee.PhoneNumber;
        TraineeVM.Grade = Trainee.Grade;
        TraineeVM.DepartmentId = Trainee.DepartmentId;
        TraineeVM.CourseResults = _context.CourseResults.ToList();
        TraineeVM.Department = _context.Departments.ToList();

        return View("Edit", TraineeVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditTrainee trainee)
    {
        if (ModelState.IsValid)
        {
            Trainee TraineeData = _context.Trainees.FirstOrDefault(ins => ins.Id == trainee.Id);
            TraineeData.Id = trainee.Id;
            TraineeData.Name = trainee.Name;
            TraineeData.PhoneNumber = trainee.PhoneNumber;
            TraineeData.Grade = trainee.Grade;
            TraineeData.DepartmentId = trainee.DepartmentId;
            
          
            trainee.CourseResults = _context.CourseResults.ToList();
            trainee.Department = _context.Departments.ToList();
          
            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        else
        {
            trainee.Department = _context.Departments.ToList();
            return View("Edit", trainee);
        }
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        Trainee? trainee = _context.Trainees
            .FirstOrDefault(i => i.Id == id);

        if (trainee == null)
            return NotFound();

        _context.Trainees.Remove(trainee);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}