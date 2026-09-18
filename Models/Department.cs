namespace Project.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ManagerName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public List<Instructor> Instructors { get; set; }
    public List<Course> Courses { get; set; }
    public List<Trainee>? Trainees { get; set; }
}