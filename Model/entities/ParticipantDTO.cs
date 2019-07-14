using System;
using System.Collections.Generic;

namespace Model.entities
{
    [Serializable]
    public class ParticipantDTO
    {
        public Participant Participant { get; set; }
        public IList<Proba> Probe { get; set; }

        public ParticipantDTO(Participant participant, IList<Proba> probe)
        {
            Participant = participant;
            Probe = probe;
        }

        
    }
}
