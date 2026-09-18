using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models.ViewModels;

public class EditResult
{
    public int Id{ get; set; }
    public decimal Degree { get; set; }
    public int CourseId { get; set; }
    
    [ValidateNever]
    public List<Course> Course { get; set; }
    
    public int TraineeId { get; set; }
    [ValidateNever]
    public List<Trainee> Trainee { get; set; }
}