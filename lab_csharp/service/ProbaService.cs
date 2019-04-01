using lab_c.Model;
using lab_c.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.service
{
    public class ProbaService : IService<int, Proba>
    {
        private ProbaRepository probaRepository;

        public ProbaService(ProbaRepository probaRepository)
        {
            this.probaRepository = probaRepository;
        }

        public void delete(int id)
        {
            probaRepository.delete(id);
        }

        public List<Proba> findAll()
        {
            return probaRepository.findAll();
        }

        public Proba findOne(int id)
        {
            return probaRepository.findOne(id);
        }

        public void save(Proba entity)
        {
            probaRepository.save(entity);
        }

        public List<Proba> findAllForArbitru(User user)
        {
            return probaRepository.findAllForArbitru(user);
        }
    }
}
