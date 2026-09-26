using Project.Models;

namespace Project.Interfaces;

public interface IResultRepository: IGenericRepository<CourseResult>
{
    IQueryable<CourseResult> GetResultDetails();
    IQueryable<CourseResult> GetResultWithDepartments();
}