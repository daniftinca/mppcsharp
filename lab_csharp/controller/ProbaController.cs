using lab_c.Model;
using lab_csharp.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.controller
{
    public class ProbaController
    {
        private ProbaService probaService;

        public ProbaController(ProbaService probaService)
        {
            this.probaService = probaService;
        }

        public Proba findOne(int id)
        {
            return probaService.findOne(id);
        }


        public List<Proba> findAll()
        {
            return probaService.findAll();
        }

        public List<Proba> findAllForArbitru(User user)
        {
            return probaService.findAllForArbitru(user);
        }



    }
}
