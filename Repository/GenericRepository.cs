using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces;

namespace Project.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T  : class
{
    private readonly AppDbContext _context;
    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public T GetById(int id)
    {
        var result = _context.Find<T>(id);
        return result;
    }

    public void Add(T item)
    {
        _context.Add(item);
    }

    public void Edit(int id)
    {
        _context.Update(id);
    }

    public void Delete(int id)
    {
        var result = _context.Find<T>(id);
        _context.Remove(result);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}