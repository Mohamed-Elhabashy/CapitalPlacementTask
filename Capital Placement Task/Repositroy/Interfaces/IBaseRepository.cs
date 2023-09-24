namespace Capital_Placement_Task.Repositroy.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        // Create
        void Add(T entity);

        // Read
        T GetById(int id);
        IEnumerable<T> GetAll();

        // Update
        T Update(int id,T entity);

        // Delete
        bool Delete(int id);
    }
}
