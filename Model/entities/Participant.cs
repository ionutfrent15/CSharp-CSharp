using System;

namespace Model.entities
{
    [Serializable]
    public class Participant : IHasID<int>
    {
        public Participant(int id, string nume, int varsta)
        {
            ID = id;
            Nume = nume;
            Varsta = varsta;
        }

        public int ID { get; set; }
        public string Nume { get; set; }
        public int Varsta { get; set; }

        public override string ToString()
        {
            return "Id: " + ID + ", Nume: " + Nume + ", Varsta: " + Varsta;
        }
    }
}
