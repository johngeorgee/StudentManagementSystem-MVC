using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Repository;

public class TraineeRepository: GenericRepository<Trainee>, ITraineeRepository
{
    private readonly AppDbContext _context;

    public TraineeRepository(AppDbContext context) : base(context)
    {
        _context = context;
        
    }

    public IQueryable<Trainee> GetTraineeDetails()
    {
        return  _context.Trainees
                           .Include(c => c.CourseResults)
                           .Include(d => d.Department);
    }
}