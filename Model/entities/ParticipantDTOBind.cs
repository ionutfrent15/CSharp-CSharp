namespace Model.entities
{
    public class ParticipantDTOBind
    {
        public Participant Participant { get; set; }
        public string Probe { get; set; }

        public ParticipantDTOBind(ParticipantDTO dto)
        {
            Participant = dto.Participant;
            Probe = "";
            foreach(var proba in dto.Probe)
            {
                Probe = Probe + proba + ", ";
            }
        }
    }
}
