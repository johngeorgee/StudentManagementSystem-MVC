using Project.Models;

namespace Project.Interfaces;

public interface IDepartmentRepository: IGenericRepository<Department>
{
    IQueryable<Department> GetDepartmentDetails();
}