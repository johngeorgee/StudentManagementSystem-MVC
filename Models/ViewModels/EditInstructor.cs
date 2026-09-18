using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models.ViewModels;

public class EditInstructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public int DepartmentId { get; set; }
    [ValidateNever]
    public List<Department> Department { get; set; }
    public int CourseId { get; set; }
    [ValidateNever]
    public List<Course> Course { get; set; }
}