using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Project.Models.ViewModels;

public class EditTrainee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Grade { get; set; }
    public int DepartmentId { get; set; }
    [ValidateNever] 
    public List<Department> Department { get; set; }
    public int CourseResultId { get; set; }
    [ValidateNever]
    public List<CourseResult> CourseResults { get; set; }
}