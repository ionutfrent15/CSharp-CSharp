using Model.entities;
using System.Collections.Generic;
using System.Data;

namespace Server.repository
{
    class ParticipantRepository : ICrudRepository<int, Participant>
    {
        IDictionary<string, string> props;

        public ParticipantRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }

        public Participant FindOne(int id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Participanti where id=@id";
                IDbDataParameter paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int idParticipant = dataReader.GetInt32(0);
                        string nume = dataReader.GetString(1);
                        int varsta = dataReader.GetInt32(2);
                        Participant participant = new Participant(idParticipant, nume, varsta);
                        return participant;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Participant> FindAll()
        {
            IDbConnection connection = DBUtils.getConnection(props);
            IList<Participant> list = new List<Participant>();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Participanti";
                using(var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int idParticipant = dataReader.GetInt32(0);
                        string nume = dataReader.GetString(1);
                        int varsta = dataReader.GetInt32(2);
                        Participant participant = new Participant(idParticipant, nume, varsta);
                        list.Add(participant);
                    }
                }
            }
            return list;
        }

        public void Save(Participant entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Participanti values (@id, @nume, @varsta)";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramNume = command.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                command.Parameters.Add(paramNume);

                var paramVarsta = command.CreateParameter();
                paramVarsta.ParameterName = "@varsta";
                paramVarsta.Value = entity.Varsta;
                command.Parameters.Add(paramVarsta);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Participanti where id=@id";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, Participant entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update Participanti set id=@id, nume=@nume, varsta=@varsta where id=@idP";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramNume = command.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                command.Parameters.Add(paramNume);

                var paramVarsta = command.CreateParameter();
                paramVarsta.ParameterName = "@varsta";
                paramVarsta.Value = entity.Varsta;
                command.Parameters.Add(paramVarsta);

                var paramIdP = command.CreateParameter();
                paramIdP.ParameterName = "@idP";
                paramIdP.Value = id;
                command.Parameters.Add(paramIdP);

                command.ExecuteNonQuery();
            }
        }

        public int LastId()
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select max(id) from Participanti";
               
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int idParticipant = dataReader.GetInt32(0) + 1;
                        return idParticipant;
                    }
                }
            }
            return -1;
        }
    }
}
