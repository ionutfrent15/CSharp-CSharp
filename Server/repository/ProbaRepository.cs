using Model.entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Server.repository
{
    class ProbaRepository : ICrudRepository<int, Proba>
    {
        IDictionary<string, string> props;

        public ProbaRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }

        public Proba FindOne(int id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Probe where id=@id";
                IDbDataParameter paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int idProba = dataReader.GetInt32(0);
                        string distantaStr = dataReader.GetString(1);
                        string stilStr = dataReader.GetString(2);
                        Distanta distanta = (Distanta)Enum.Parse(typeof(Distanta), distantaStr);
                        Stil stil = (Stil)Enum.Parse(typeof(Stil), stilStr);
                        Proba proba = new Proba(idProba, distanta, stil);
                        return proba;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Proba> FindAll()
        {
            IDbConnection connection = DBUtils.getConnection(props);
            IList<Proba> list = new List<Proba>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Probe";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int idProba = dataReader.GetInt32(0);
                        string distantaStr = dataReader.GetString(1);
                        string stilStr = dataReader.GetString(2);
                        Distanta distanta = (Distanta)Enum.Parse(typeof(Distanta), distantaStr);
                        Stil stil = (Stil)Enum.Parse(typeof(Stil), stilStr);
                        Proba proba = new Proba(idProba, distanta, stil);
                        list.Add(proba);
                    }
                }
            }
            return list;
        }

        public void Save(Proba entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Probe values (@id, @distanta, @stil)";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramDist = command.CreateParameter();
                paramDist.ParameterName = "@distanta";
                paramDist.Value = entity.Distanta.ToString();
                command.Parameters.Add(paramDist);

                var paramStil = command.CreateParameter();
                paramStil.ParameterName = "@stil";
                paramStil.Value = entity.Stil.ToString();
                command.Parameters.Add(paramStil);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Probe where id=@id";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, Proba entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update Probe set id=@id, distanta=@distanta, stil=@stil where id=@idP";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramDist = command.CreateParameter();
                paramDist.ParameterName = "@distanta";
                paramDist.Value = entity.Distanta.ToString();
                command.Parameters.Add(paramDist);

                var paramStil = command.CreateParameter();
                paramStil.ParameterName = "@stil";
                paramStil.Value = entity.Stil.ToString();
                command.Parameters.Add(paramStil);

                var paramIdP = command.CreateParameter();
                paramIdP.ParameterName = "@idP";
                paramIdP.Value = id;
                command.Parameters.Add(paramIdP);

                command.ExecuteNonQuery();
            }
        }
    }
}
