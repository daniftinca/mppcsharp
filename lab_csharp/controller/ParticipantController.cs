using lab_c.Model;
using lab_csharp.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.controller
{
    public class ParticipantController
    {
        private ParticipantService participantService;

        public ParticipantController(ParticipantService participantService)
        {
            this.participantService = participantService;
        }

        public Participant findOne(int id)
        {
            return participantService.findOne(id);
        }


        public List<Participant> findAll()
        {
            return participantService.findAll();
        }

        public List<Participant> getParticipantWithNoScoreForProba(Proba proba) {
            return participantService.getParticipantWithNoScoreForProba(proba);
        }


    }
}
