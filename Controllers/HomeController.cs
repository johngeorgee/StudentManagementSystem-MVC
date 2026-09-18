using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.ViewModels;
using Project.Models;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var courseResults = _context.CourseResults
            .Include(t=> t.Trainee)
            .Include(r => r.Course)
            .ThenInclude(c => c.Department)
            .Take(6).ToList();

        
        var dashboard = new Dashboard()
        {
            CourseResults = courseResults,
            TotalCourses = _context.Courses.Count(),
            TotalDepartments = _context.Departments.Count(),
            TotalInstructors = _context.Instructors.Count(),
            TotalTrainees = _context.Trainees.Count()
            
        };
        ViewBag.PageTitle      = "Dashboard Overview";
        ViewBag.WelcomeMessage = $"Welcome back, Admin";
        
        ViewData["Page Title"]   = "Dashboard";
        ViewData["Project Name"]   = "Student MS";
        return View(dashboard);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}