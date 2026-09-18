using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models.ViewModels;

public class EditCourse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Degree { get; set; }

    public int DepartmentId { get; set; }
    
     [ValidateNever]
    public List<Department> Department { get; set; }
    
   
}