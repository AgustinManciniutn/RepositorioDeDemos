namespace sigmaHashAlpha.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> Add(T Entity);
        Task<bool> Delete(string id);
        Task<bool> Upsert(T Entity, string id);
    }
}
