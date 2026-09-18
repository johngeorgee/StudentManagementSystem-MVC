namespace Project.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Degree { get; set; }
    public int MinDegree { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<Instructor>  Instructors { get; set; }
    public List<CourseResult>? CourseResults { get; set; }
}