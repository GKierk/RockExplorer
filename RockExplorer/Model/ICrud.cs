/*
 * Author: Gabriel H. Kierkegaard, Date: 08-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 15-05-2023
 */

namespace RockExplorer.Model
{
    public interface ICRUD<T>
    {
        public void Create(T entity);
        public T Read(int key);
        public Dictionary<int, T> ReadAll();
        public void Update(int key, T entity);
        public void Delete(int key);
    }
}
