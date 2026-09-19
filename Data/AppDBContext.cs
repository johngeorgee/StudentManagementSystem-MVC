using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class AppDbContext : DbContext
{
    
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseResult>  CourseResults { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Department>().HasQueryFilter(d=> !d.IsDeleted).HasData(
            new Department { Id = 1, Name = "Computer Science",       ManagerName = "Dr. Ahmed Hassan" },
            new Department { Id = 2, Name = "Information Systems",    ManagerName = "Dr. Mona Khalil" },
            new Department { Id = 3, Name = "Software Engineering",   ManagerName = "Dr. Youssef Adel" },
            new Department { Id = 4, Name = "Artificial Intelligence",ManagerName = "Dr. Sara Ibrahim" },
            new Department { Id = 5, Name = "Cybersecurity",          ManagerName = "Dr. Khaled Mostafa" }
        );
        
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Introduction to Programming",   Degree = 100, MinDegree = 50, DepartmentId = 1 },
            new Course { Id = 2, Name = "Database Systems",              Degree = 100, MinDegree = 60, DepartmentId = 1 },
            new Course { Id = 3, Name = "Object-Oriented Design",        Degree = 100, MinDegree = 55, DepartmentId = 2 },
            new Course { Id = 4, Name = "Machine Learning Fundamentals", Degree = 100, MinDegree = 65, DepartmentId = 3 },
            new Course { Id = 5, Name = "Network Security",              Degree = 100, MinDegree = 60, DepartmentId = 4 }
        );
        
        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { Id = 1, Name = "Dr. Ahmed Hassan",  ImageUrl = "/Images/male_avatar.jpeg",   Address = "Cairo, Nasr City",   Phone = "01001234567", Email = "ahmed.hassan@uni.edu",  Salary = 15000, DepartmentId = 1, CourseId = 1 },
            new Instructor { Id = 2, Name = "Dr. Hala Sami",     ImageUrl = "/Images/female.jpeg",   Address = "Cairo, Heliopolis",  Phone = "01002234567", Email = "hala.sami@uni.edu",     Salary = 14500, DepartmentId = 1, CourseId = 1 },
            new Instructor { Id = 3, Name = "Dr. Tarek Fouad",   ImageUrl = "/Images/male_avatar.jpeg",   Address = "Giza, Haram",        Phone = "01103234567", Email = "tarek.fouad@uni.edu",   Salary = 14800, DepartmentId = 1, CourseId = 1 },
            new Instructor { Id = 4, Name = "Dr. Mona Khalil",   ImageUrl = "/Images/female.jpeg",    Address = "Giza, Dokki",        Phone = "01102345678", Email = "mona.khalil@uni.edu",   Salary = 16000, DepartmentId = 1, CourseId = 2 },
            new Instructor { Id = 5, Name = "Dr. Rania Wagdy",   ImageUrl = "/Images/female.jpeg",    Address = "Cairo, Maadi",       Phone = "01004567890", Email = "rania.wagdy@uni.edu",   Salary = 15200, DepartmentId = 1, CourseId = 2 },
            new Instructor { Id = 6, Name = "Dr. Youssef Adel",  ImageUrl = "/Images/male_avatar.jpeg", Address = "Alexandria, Smouha", Phone = "01203456789", Email = "youssef.adel@uni.edu",  Salary = 15500, DepartmentId = 2, CourseId = 3 },
            new Instructor { Id = 7, Name = "Dr. Sara Ibrahim",  ImageUrl = "/Images/female.jpeg",    Address = "Cairo, Maadi",       Phone = "01005567890", Email = "sara.ibrahim@uni.edu",  Salary = 17500, DepartmentId = 3, CourseId = 4 },
            new Instructor { Id = 8, Name = "Dr. Khaled Mostafa",ImageUrl = "/Images/male_avatar.jpeg",  Address = "Cairo, Heliopolis",  Phone = "01105678901", Email = "khaled.mostafa@uni.edu",Salary = 16500, DepartmentId = 4, CourseId = 5 }
        );
        
        modelBuilder.Entity<Trainee>().HasData(
            new Trainee { Id = 1, Name = "Ali Mahmoud",  ImageUrl = "/Images/male_trainee.jpeg",    PhoneNumber = "01011111111", Grade = 88.5m, DepartmentId = 1 },
            new Trainee { Id = 2, Name = "Salma Nabil",  ImageUrl = "/Images/female_trainee.jpeg",   PhoneNumber = "01112222222", Grade = 92.0m, DepartmentId = 1 },
            new Trainee { Id = 3, Name = "Omar Tarek",   ImageUrl = "/Images/male_trainee.jpeg",    PhoneNumber = "01213333333", Grade = 79.5m, DepartmentId = 2 },
            new Trainee { Id = 4, Name = "Nour Adel",    ImageUrl = "/Images/male_trainee.jpeg",   PhoneNumber = "01014444444", Grade = 85.0m, DepartmentId = 2 },
            new Trainee { Id = 5, Name = "Yousef Samir", ImageUrl = "/Images/male_trainee.jpeg", PhoneNumber = "01115555555", Grade = 74.0m, DepartmentId = 3 },
            new Trainee { Id = 6, Name = "Hana Wael",    ImageUrl = "/Images/female_trainee.jpeg",    PhoneNumber = "01216666666", Grade = 90.0m, DepartmentId = 4 },
            new Trainee { Id = 7, Name = "Karim Hossam", ImageUrl = "/Images/male_trainee.jpeg",   PhoneNumber = "01017777777", Grade = 68.0m, DepartmentId = 5 }
        );
        
        modelBuilder.Entity<CourseResult>().HasData(
            new CourseResult { Id = 1,  TraineeId = 1, CourseId = 1, Degree = 90m },
            new CourseResult { Id = 2,  TraineeId = 1, CourseId = 2, Degree = 78m },
            new CourseResult { Id = 3,  TraineeId = 1, CourseId = 3, Degree = 82m },
            new CourseResult { Id = 4,  TraineeId = 2, CourseId = 1, Degree = 95m },
            new CourseResult { Id = 5,  TraineeId = 2, CourseId = 2, Degree = 88m },
            new CourseResult { Id = 6,  TraineeId = 3, CourseId = 3, Degree = 70m },
            new CourseResult { Id = 7,  TraineeId = 3, CourseId = 4, Degree = 55m }, // fail
            new CourseResult { Id = 8,  TraineeId = 4, CourseId = 4, Degree = 72m },
            new CourseResult { Id = 9,  TraineeId = 5, CourseId = 5, Degree = 62m },
            new CourseResult { Id = 10, TraineeId = 6, CourseId = 5, Degree = 80m },
            new CourseResult { Id = 11, TraineeId = 7, CourseId = 5, Degree = 58m }  // fail
        );
        
    }
    
}