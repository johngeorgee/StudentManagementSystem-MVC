using Project.Models.ViewModels;

namespace Project.Models.ViewModels;

public class Dashboard
{
    
    public List<CourseResult>  CourseResults { get; set; }
   
    public int TotalInstructors { get; set; }
    public int TotalCourses { get; set; }
    public int TotalDepartments { get; set; }
    public int TotalTrainees { get; set; }
}