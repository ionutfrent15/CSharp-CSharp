using System;

namespace Model.entities
{
    [Serializable]
    public class Oficiu : IHasID<string>
    {
        public Oficiu(string id, string password)
        {
            ID = id;
            Password = password;
        }

        public string ID { get; set; }
        public string Password { get; set; }
    }
}
