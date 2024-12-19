namespace Blog.WebClient.Services;

public interface IBaseService<T>
{
    Task<List<T>> GetListAsync(); 
    Task<T?> InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(int entityId);  
    Task<T?> GetById(int id);
}
