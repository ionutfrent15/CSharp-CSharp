using Model.entities;
using System.Collections.Generic;
using System.Data;

namespace Server.repository
{
    class InscriereRepository : ICrudRepository<KeyValuePair<int, int>, Inscriere>
    {
        IDictionary<string, string> props;

        public InscriereRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }

        public Inscriere FindOne(KeyValuePair<int, int> id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Inscrieri where idParticipant=@idParticipant and idProba=@idProba";
                IDbDataParameter paramIdParticipant = command.CreateParameter();
                paramIdParticipant.ParameterName = "@idParcitipant";
                paramIdParticipant.Value = id.Key;
                command.Parameters.Add(paramIdParticipant);

                IDbDataParameter paramIdProba = command.CreateParameter();
                paramIdProba.ParameterName = "@idProba";
                paramIdProba.Value = id.Value;
                command.Parameters.Add(paramIdProba);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int idParticipant = dataReader.GetInt32(0);
                        int idProba = dataReader.GetInt32(1);
                        Inscriere inscriere = new Inscriere(new KeyValuePair<int, int>(idParticipant, idProba));
                        return inscriere;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Inscriere> FindAll()
        {
            IDbConnection connection = DBUtils.getConnection(props);
            IList<Inscriere> list = new List<Inscriere>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Inscrieri";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int idParticipant = dataReader.GetInt32(0);
                        int idProba = dataReader.GetInt32(1);
                        Inscriere inscriere = new Inscriere(new KeyValuePair<int, int>(idParticipant, idProba));
                        list.Add(inscriere);
                    }
                }
            }
            return list;
        }

        public void Save(Inscriere entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Inscrieri values (@idParticipant, @idProba)";

                IDbDataParameter paramIdParticipant = command.CreateParameter();
                paramIdParticipant.ParameterName = "@idParticipant";
                paramIdParticipant.Value = entity.ID.Key;
                command.Parameters.Add(paramIdParticipant);

                IDbDataParameter paramIdProba = command.CreateParameter();
                paramIdProba.ParameterName = "@idProba";
                paramIdProba.Value = entity.ID.Value;
                command.Parameters.Add(paramIdProba);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(KeyValuePair<int, int> id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Inscrieri where idParticipant=@idParticipant and idProba=@idProba";

                IDbDataParameter paramIdParticipant = command.CreateParameter();
                paramIdParticipant.ParameterName = "@idParticipant";
                paramIdParticipant.Value = id.Key;
                command.Parameters.Add(paramIdParticipant);

                IDbDataParameter paramIdProba = command.CreateParameter();
                paramIdProba.ParameterName = "@idProba";
                paramIdProba.Value = id.Value;
                command.Parameters.Add(paramIdProba);

                command.ExecuteNonQuery();
            }
        }
        
        public void Update(KeyValuePair<int, int> id, Inscriere entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update Inscrieri set idParticipant=@idParticipant, idProba=@idProba where idParticipant=@idPart and idProba=@idPr";

                IDbDataParameter paramIdParticipant = command.CreateParameter();
                paramIdParticipant.ParameterName = "@idParticipant";
                paramIdParticipant.Value = entity.ID.Key;
                command.Parameters.Add(paramIdParticipant);

                IDbDataParameter paramIdProba = command.CreateParameter();
                paramIdProba.ParameterName = "@idProba";
                paramIdProba.Value = entity.ID.Value;
                command.Parameters.Add(paramIdProba);

                IDbDataParameter paramIdPart = command.CreateParameter();
                paramIdPart.ParameterName = "@idPart";
                paramIdPart.Value = id.Key;
                command.Parameters.Add(paramIdPart);

                IDbDataParameter paramIdPr = command.CreateParameter();
                paramIdPr.ParameterName = "@idPr";
                paramIdPr.Value = id.Value;
                command.Parameters.Add(paramIdPr);

                command.ExecuteNonQuery();
            }
        }

        public IDictionary<int, int> FindDTO()
        {
            IDbConnection connection = DBUtils.getConnection(props);
            IDictionary<int, int> map = new Dictionary<int, int>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "select idProba, count(*) as no from Inscrieri group by idProba";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        int no = dataReader.GetInt32(1);
                        map[id] = no;
                    }
                }
            }
            return map;
        }

        public IList<int> FindParticipantByProba(int idProba)
        {
            IList<int> participants = new List<int>();
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "select idParticipant from Inscrieri where idProba=@idProba";
                IDbDataParameter paramIdProba = command.CreateParameter();
                paramIdProba.ParameterName = "@idProba";
                paramIdProba.Value = idProba;
                command.Parameters.Add(paramIdProba);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        participants.Add(id);
                    }
                }
                return participants;
            }
        }

        public IList<int> FindProbaByParticipant(int idParticipant)
        {
            IList<int> probe = new List<int>();
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "select idProba from Inscrieri where idParticipant=@idParticipant";
                IDbDataParameter paramIdParticipant = command.CreateParameter();
                paramIdParticipant.ParameterName = "@idParticipant";
                paramIdParticipant.Value = idParticipant;
                command.Parameters.Add(paramIdParticipant);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        probe.Add(id);
                    }
                }
                return probe;
            }
        }
    }
}
