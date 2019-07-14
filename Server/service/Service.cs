using Model.entities;
using Model.utils;
using Server.repository;
using System.Collections.Generic;

namespace Server.service
{
    class Service : IObservable
    {
        OficiuRepository oficiuRepository;
        ParticipantRepository participantRepository;
        ProbaRepository probaRepository;
        InscriereRepository inscriereRepository;

        private IList<IObserver> observers = new List<IObserver>();

        public Service(OficiuRepository oficiuRepository, ParticipantRepository participantRepository, ProbaRepository probaRepository, InscriereRepository inscriereRepository)
        {
            this.oficiuRepository = oficiuRepository;
            this.participantRepository = participantRepository;
            this.probaRepository = probaRepository;
            this.inscriereRepository = inscriereRepository;
        }

        public bool ValidateLogin(string user, string password)
        {
            Oficiu oficiu = oficiuRepository.FindOne(user);
            if(oficiu == null)
            {
                return false;
            }
            else
            {
                return oficiu.Password.Equals(password);
            }
        }

        public IList<ProbaDTO> FindDTO()
        {
            IList<ProbaDTO> list = new List<ProbaDTO>();
            var map = inscriereRepository.FindDTO();
            var probe = probaRepository.FindAll();
            foreach(var proba in probe)
            {
                if (map.ContainsKey(proba.ID))
                {
                    list.Add(new ProbaDTO(proba, map[proba.ID]));
                }
                else
                {
                    list.Add(new ProbaDTO(proba, 0));
                }
            }
            return list;
        }

        public void InscrieParticipant(string nume, int varsta, IList<ProbaDTO> probe)
        {
            //nume = nume + " " + prenume;
            int id = participantRepository.LastId();
            Participant participant = new Participant(id, nume, varsta);
            participantRepository.Save(participant);
            foreach(var dto in probe)
            {
                Inscriere inscriere = new Inscriere(new KeyValuePair<int, int>(id, dto.Proba.ID));
                inscriereRepository.Save(inscriere);
            }
            NotifyAll();
        }

        public IList<ParticipantDTO> CautaParticipantiByProba(int idPr)
        {
            Proba proba = probaRepository.FindOne(idPr);
            IList<ParticipantDTO> participantDTOs = new List<ParticipantDTO>();
            var ids = inscriereRepository.FindParticipantByProba(proba.ID);
            foreach(int id in ids)
            {
                Participant participant = participantRepository.FindOne(id);
                var idProbe = inscriereRepository.FindProbaByParticipant(id);
                IList<Proba> probe = new List<Proba>();
                foreach(var idProba in idProbe)
                {
                    Proba findProba = probaRepository.FindOne(idProba);
                    probe.Add(findProba);
                }
                ParticipantDTO dto = new ParticipantDTO(participant, probe);
                participantDTOs.Add(dto);
            }
            return participantDTOs;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyAll()
        {
            foreach(var o in observers)
            {
                o.Update();
            }
        }
    }
}
