/*
 * Author: Gabriel H. Kierkegaard
 * Date: 08-05-2023
 */

namespace RockExplorer.Model
{
    public interface ICrud<T>
    {
        public T Create(T entity);
        public T Read(int id);
        public List<T> ReadAll();
        public void Update(T entity);
        public void Delete(int id);
    }
}
