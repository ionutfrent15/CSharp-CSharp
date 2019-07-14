using System;
using System.Collections.Generic;

namespace Model.entities
{
    [Serializable]
    public class Inscriere : IHasID<KeyValuePair<int, int>>
    {
        public Inscriere(KeyValuePair<int, int> iD)
        {
            ID = iD;
        }

        public KeyValuePair<int, int> ID { get; set; }

        public override string ToString()
        {
            return ID.Key + " " + ID.Value;
        }
    }
}
