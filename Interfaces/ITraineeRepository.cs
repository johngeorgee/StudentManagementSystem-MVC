using Project.Models;

namespace Project.Interfaces;

public interface ITraineeRepository : IGenericRepository<Trainee>
{
    IQueryable<Trainee> GetTraineeDetails();
}