using lab_c.Model;
using lab_csharp.repository;
using lab_csharp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.service
{
    public class ScorService : IService<int, Scor>
    {
        ScorRepository scorRepository;

        public ScorService(ScorRepository scorRepository)
        {
            this.scorRepository = scorRepository;
        }

        public void delete(int id)
        {
            scorRepository.delete(id);
        }

        public List<Scor> findAll()
        {
            return scorRepository.findAll();
        }

        public Scor findOne(int id)
        {
            return scorRepository.findOne(id);
        }

        public void save(Scor entity)
        {
            scorRepository.save(entity);
        }

        public List<Scor> getScoruriFromProba(Proba proba) {
            return scorRepository.getScoresFromProba(proba);
        }

        public List<ScoreTotal> getNrTotalDePuncte() {
            return scorRepository.getScoreTotals();
        }
    }
}
