/*
 * Author: Gabriel H. Kierkegaard
 * Date: 08-05-2023
 */

namespace RockExplorer.Model
{
    public interface ICRUD<T>
    {
        public void Create(T entity);
        public T Read(int id);
        public Dictionary<int, T> ReadAll();
        public void Update(T entity);
        public void Delete(int id);
    }
}
