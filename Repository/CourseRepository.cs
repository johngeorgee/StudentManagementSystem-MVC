
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Repository;

public class CourseRepository: GenericRepository<Course>, ICourseRepository
{
   private readonly AppDbContext _context;

   public CourseRepository(AppDbContext context): base(context)
   {
      _context = context;
   }

   public IQueryable<Course> GetCourseDetails()
   {
      return _context.Courses
         .Include(r => r.CourseResults)
         .ThenInclude(t => t.Trainee)
         .Include(t => t.Instructors)
         .Include(d => d.Department);
   }
}