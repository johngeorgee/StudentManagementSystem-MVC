namespace Project.Interfaces;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T  GetById(int id);
    void Add(T item);
    void Edit(int id);
    void Delete(int id);
    void SaveChanges();
}