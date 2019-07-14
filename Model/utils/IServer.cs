using Model.entities;
using System.Collections.Generic;

namespace Model.utils
{
    public interface IServer
    {
        bool Login(Oficiu oficiu, IObserver client);
        IList<ProbaDTO> FindAllProbaDTO();
        bool Logout(IObserver client);
        void InscrieParticipant(string nume, int varsta, IList<ProbaDTO> probe);
        IList<ParticipantDTO> FindAllParticipantByProba(Proba proba);
    }
}
