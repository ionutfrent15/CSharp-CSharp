using System;

namespace Model.entities
{
    [Serializable]
    public class ProbaDTO
    {
        public Proba Proba { get; set; }
        public int NoParticipanti { get; set; }

        public ProbaDTO(Proba proba, int noParticipanti)
        {
            this.Proba = proba;
            this.NoParticipanti = noParticipanti;
        }

        public override string ToString()
        {
            var dist = Proba.Distanta.ToString();
            dist = dist.Replace("dist", "");
            return dist + " " + Proba.Stil.ToString();
        }
    }
}
