using System.Collections.Generic;

namespace Server.repository
{
    public interface ICrudRepository<ID, E>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        void Save(E entity);
        void Delete(ID id);
        void Update(ID id, E entity);
    }
}
