using System;

namespace Model.entities
{
    [Serializable]
    public class Proba : IHasID<int>
    {
        public Proba(int iD, Distanta distanta, Stil stil)
        {
            ID = iD;
            Distanta = distanta;
            Stil = stil;
        }

        public int ID { get; set; }
        public Distanta Distanta { get; set; }
        public Stil Stil { get; set; }

        public override string ToString()
        {
            var dist = Distanta.ToString();
            dist = dist.Replace("dist", "");
            return dist + " " + Stil.ToString();
        }
    }
}
