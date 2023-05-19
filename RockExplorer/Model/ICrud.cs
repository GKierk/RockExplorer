/*
 * Author: Gabriel H. Kierkegaard, Date: 08-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 15-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 17-05-2023
 */

//Dette en simpel beskrivelse af en Interface kaldet ICRUD, der definerer fem grundlæggende operationer (Create, Read, Update, Delete) for at håndtere data for en type T Liste/ordbog.-MK

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
