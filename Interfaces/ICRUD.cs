using MIAPI.Models;

namespace MIAPI.Interfaces
{
    public interface ICRUD <T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Create(T entidad);
        Task Update(T entidad);
        Task Delete(int id);
    }
}
