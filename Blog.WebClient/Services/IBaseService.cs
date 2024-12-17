namespace Blog.WebClient.Services;

public interface IBaseService<T>
{
    Task<List<T>> GetListAsync(); 
    Task<ServiceResult<T>> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int entityId);  
    Task<T> GetById(int id);
}
