using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class CourseResultController : Controller
{
    private readonly AppDbContext _context;

    public CourseResultController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index(string search)
    {
        var results = _context.CourseResults.AsQueryable()
            .Include(t => t.Trainee)
            .Include(c => c.Course);

        if (!string.IsNullOrWhiteSpace(search))
        {
            results = results.Where(r => r.Course.Name.Contains(search))
                .Include(t => t.Trainee)
                .Include(c => c.Course);
        }
        return View(results.ToList());
    }
    public IActionResult ShowById(int id)
    {
        var result = _context.CourseResults
            .Include(t => t.Trainee)
            .Include(c => c.Course)
            .FirstOrDefault(r => r.Id == id);
        return View(result);
    }
    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(
            _context.Courses.ToList(),
            "Id",
            "Name"
        );
        ViewBag.Trainees = new SelectList(
            _context.Trainees.ToList(),
            "Id",
            "Name"
        );
        return View("Create");
    }
    public IActionResult Add(CourseResult courseResult)
    {
        if (courseResult != null)
        {
            _context.CourseResults.Add(courseResult);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(courseResult);
    }
    [HttpGet] 
    public IActionResult Edit(int id)
    {
        CourseResult Result = _context.CourseResults.FirstOrDefault(r => r.Id == id);

        EditResult ResultVM = new EditResult();
        ResultVM.Id = Result.Id;
        ResultVM.Degree = Result.Degree;
        ResultVM.CourseId = Result.CourseId;
        ResultVM.TraineeId = Result.TraineeId;
        ResultVM.Course =  _context.Courses.ToList();
        ResultVM.Trainee =  _context.Trainees.ToList();

        return View("Edit", ResultVM);
    }

    [HttpPost]
    public IActionResult SaveEdit(EditResult result)
    {
        if (ModelState.IsValid)
        {
            CourseResult ResultData = _context.CourseResults.FirstOrDefault(c => c.Id == result.Id);
            ResultData.Id = result.Id;
            ResultData.Degree = result.Degree;
            ResultData.CourseId = result.CourseId;
            ResultData.TraineeId = result.TraineeId;
            result.Course = _context.Courses.ToList();
            result.Trainee = _context.Trainees.ToList();
            _context.SaveChanges();
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
            CourseResult? result = _context.CourseResults
                .FirstOrDefault(i => i.Id == id);

            if (result == null)
                return NotFound();

            _context.CourseResults.Remove(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
}