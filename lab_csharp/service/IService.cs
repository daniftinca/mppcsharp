using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.service
{
    interface IService<ID, T>
    {
        void save(T entity);

        void delete(ID id);

        T findOne(ID id);

        List<T> findAll();
    }
}
