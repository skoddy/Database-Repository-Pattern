using System.Collections.Generic;

// Hier werden alle typischen CRUD Methoden definiert.
// Zusätlich eine Methode für alle Datensätze,
// und eine Methode für einen Datensatz.

namespace DatabaseApp
{
    public interface IRepository <T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Insert(T model);
        public void Update(T model);
        public void Delete(int id);
    }
}
