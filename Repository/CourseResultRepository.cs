using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Repository;

public class CourseResultRepository : GenericRepository<CourseResult>, IResultRepository
{
    private readonly AppDbContext _context;

    public CourseResultRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<CourseResult> GetResultDetails()
    {
        return _context.CourseResults
                           .Include(t => t.Trainee)
                           .Include(c => c.Course);
    }
    public IQueryable<CourseResult> GetResultWithDepartments()
    {
        return _context.CourseResults
            .Include(t => t.Trainee)
            .Include(c => c.Course)
            .ThenInclude(c => c.Department);
    }
}