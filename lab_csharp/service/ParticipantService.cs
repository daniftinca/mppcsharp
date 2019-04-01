using lab_c.Model;
using lab_csharp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.service
{
    public class ParticipantService : IService<int, Participant>
    {
        private ParticipantRepository participantRepository;

        public ParticipantService(ParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        public void save(Participant entity)
        {
            participantRepository.save(entity);
        }

        public void delete(int id)
        {
            participantRepository.delete(id);
        }

        public Participant findOne(int id)
        {
            return participantRepository.findOne(id);
        }

        public List<Participant> findAll()
        {
            return participantRepository.findAll();
        }


        public List<Participant> getParticipantWithNoScoreForProba(Proba proba) { return participantRepository.getParticipantWithNoScoreForProba(proba); }


    }
}
