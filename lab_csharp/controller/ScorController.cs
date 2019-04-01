using lab_c.Model;
using lab_csharp.service;
using lab_csharp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.controller
{
    public class ScorController
    {
        private ScorService scorService;

        public ScorController(ScorService scorService)
        {
            this.scorService = scorService;
        }

        public Scor findOne(int id)
        {
            return scorService.findOne(id);
        }


        public List<Scor> findAll()
        {
            return scorService.findAll();
        }

        public List<Scor> getScoruriFromProba(Proba proba) {
            return scorService.getScoruriFromProba(proba);
        }

        public List<ScoreTotal> getNrTotalDePuncte()
        {
            return scorService.getNrTotalDePuncte();
        }

        public void save(Scor entity) {
            scorService.save(entity);
        }

    }
}
