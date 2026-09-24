using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Repository;

public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
{
    private readonly AppDbContext _context;

    public InstructorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Instructor> GetInstructorDetails()
    {
       return  _context.Instructors
            .Include(d => d.Department)
            .Include(c => c.Course);
    }
}