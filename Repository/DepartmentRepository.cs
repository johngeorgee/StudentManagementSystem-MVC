using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Repository;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    private readonly AppDbContext _context;
    public DepartmentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
  
    public IQueryable<Department> GetDepartmentDetails()
    {
        return _context.Departments
            .Include(c=> c.Courses)
            .Include(t => t.Trainees)
            .Include(t => t.Instructors);
    }
}