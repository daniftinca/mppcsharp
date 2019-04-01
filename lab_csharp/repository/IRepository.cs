using System.Collections.Generic;

namespace lab_c.Repository
{
    public interface IRepository<ID, T>
    {
        void save(T entity);

        void delete(ID id);

        T findOne(ID id);

        List<T> findAll();
    }
}