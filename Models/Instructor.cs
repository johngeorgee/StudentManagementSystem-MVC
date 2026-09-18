namespace Project.Models;

public class Instructor
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string? ImageUrl { get; set; }
   public string Address { get; set; }
   public string Phone { get; set; }
   public string Email { get; set; }
   public double Salary { get; set; }
   
   public int  DepartmentId { get; set; }
   public Department Department { get; set; }
   
   public int  CourseId { get; set; }
   public Course Course { get; set; }
   
}