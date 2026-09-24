using Project.Models;

namespace Project.Interfaces;

public interface IInstructorRepository: IGenericRepository<Instructor>
{
    IQueryable<Instructor> GetInstructorDetails();
}