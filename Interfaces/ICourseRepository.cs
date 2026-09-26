using Project.Models;

namespace Project.Interfaces;

public interface ICourseRepository: IGenericRepository<Course>
{
    IQueryable<Course> GetCourseDetails();
}