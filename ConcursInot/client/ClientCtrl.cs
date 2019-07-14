using Model.entities;
using Model.utils;
using System;
using System.Collections.Generic;

namespace ConcursInot.client
{

    class ClientCtrl : MarshalByRefObject, IObserver
    {
        private readonly IServer server;
        private MainWindow mainWindow;

        public ClientCtrl(IServer server)
        {
            this.server = server;
        }

        public bool Login(string user, string password)
        {
            return server.Login(new Oficiu(user, password), this);
        }

        public void SetMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public IList<ProbaDTO> FindAllProbaDTO()
        {
            return server.FindAllProbaDTO();
        }

        public void InscrieParticipant(string nume, int varsta, IList<ProbaDTO> probe)
        {
            server.InscrieParticipant(nume, varsta, probe);
        }

        public bool Logout()
        {
            server.Logout(this);
            return true;
        }

        public IList<ParticipantDTO> FindAllParticipantByProba(Proba proba)
        {
            return server.FindAllParticipantByProba(proba);
        }

        public void Update()
        {
            mainWindow.UpdateTable(server.FindAllProbaDTO());   
        }
    }
}
