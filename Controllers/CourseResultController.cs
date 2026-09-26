using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class CourseResultController : Controller
{
    private readonly IResultRepository _resultRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ITraineeRepository _traineeRepository;

    public CourseResultController( IResultRepository resultRepository,
        ICourseRepository courseRepository,  ITraineeRepository traineeRepository)
    {
        _resultRepository = resultRepository;
        _courseRepository = courseRepository;
        _traineeRepository = traineeRepository;
    }
    // GET
    public IActionResult Index(string search)
    {
        var results = _resultRepository.GetResultDetails();

        if (!string.IsNullOrWhiteSpace(search))
        {
            results = results.Where(r => r.Course.Name.Contains(search));

        }
        return View(results.ToList());
    }
    public IActionResult ShowById(int id)
    {

        var result = _resultRepository.GetResultDetails()
            .FirstOrDefault(r => r.Id == id);
        return View(result);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _courseRepository.GetAll(),
            "Id",
            "Name"
        );
        ViewBag.Trainees = new SelectList(
           _traineeRepository.GetAll(),
            "Id",
            "Name"
        );
        return View("Create");
    }
    public IActionResult Add(CourseResult courseResult)
    {
        if (courseResult != null)
        {

            _resultRepository.Add(courseResult);
            _resultRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(courseResult);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {

       CourseResult Result = _resultRepository.GetById(id);

        EditResult ResultVM = new EditResult();
        ResultVM.Id = Result.Id;
        ResultVM.Degree = Result.Degree;
        ResultVM.CourseId = Result.CourseId;
        ResultVM.TraineeId = Result.TraineeId;
        ResultVM.Course = _courseRepository.GetAll();
        ResultVM.Trainee = _traineeRepository.GetAll();

        return View("Edit", ResultVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditResult result)
    {
        if (ModelState.IsValid)
        {
            CourseResult ResultData = _resultRepository.GetById(result.Id);
            ResultData.Id = result.Id;
            ResultData.Degree = result.Degree;
            ResultData.CourseId = result.CourseId;
            ResultData.TraineeId = result.TraineeId;
            
            result.Course = _courseRepository.GetAll();
            result.Trainee =_traineeRepository.GetAll();
            _resultRepository.SaveChanges();
            return RedirectToAction("Index");

        }
        else
        {
            return View("Edit", result);
        }
    }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CourseResult? result = _resultRepository.GetById(id);

            if (result == null)
                return NotFound();

            _resultRepository.Delete(id);
            _resultRepository.SaveChanges();

            return RedirectToAction("Index");
        }
}