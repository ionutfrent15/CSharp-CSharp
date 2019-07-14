using Model.entities;
using Model.utils;
using Server.service;
using System;
using System.Collections.Generic;

namespace Server.server
{
    class ServerImplementation : MarshalByRefObject, IServer
    {
        private Service service;

        public ServerImplementation(Service service)
        {
            this.service = service;
        }

        public bool Login(Oficiu oficiu, IObserver client)
        {
            bool validate = service.ValidateLogin(oficiu.ID, oficiu.Password);
            if (validate)
            {
                service.AddObserver(client);
                return true;
            }
            return false;
        }

        public IList<ProbaDTO> FindAllProbaDTO()
        {
            return service.FindDTO();
        }

        public bool Logout(IObserver client)
        {
            service.RemoveObserver(client);
            return true;
        }

        public void InscrieParticipant(string nume, int varsta, IList<ProbaDTO> probe)
        {
            service.InscrieParticipant(nume, varsta, probe);
        }

        public IList<ParticipantDTO> FindAllParticipantByProba(Proba proba)
        {
            return service.CautaParticipantiByProba(proba.ID);
        }
    }
}
