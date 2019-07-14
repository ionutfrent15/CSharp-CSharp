using Model.entities;
using System.Collections.Generic;
using System.Data;

namespace Server.repository
{
    class OficiuRepository : ICrudRepository<string, Oficiu>
    {
        IDictionary<string, string> props;

        public OficiuRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }

        public Oficiu FindOne(string id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Oficii where id=@id";
                IDbDataParameter paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string idOficiu = dataReader.GetString(0);
                        string password = dataReader.GetString(1);
                        Oficiu oficiu = new Oficiu(idOficiu, password);
                        return oficiu;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Oficiu> FindAll()
        {
            IDbConnection connection = DBUtils.getConnection(props);
            IList<Oficiu> list = new List<Oficiu>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Oficii";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string idOficiu = dataReader.GetString(0);
                        string password = dataReader.GetString(1);
                        Oficiu oficiu = new Oficiu(idOficiu, password);
                        list.Add(oficiu);
                    }
                }
            }
            return list;
        }

        public void Save(Oficiu entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Oficii values (@id, @password)";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramPassword = command.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.Password;
                command.Parameters.Add(paramPassword);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Oficii where id=@id";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);
                command.ExecuteNonQuery();
            }
        }

        public void Update(string id, Oficiu entity)
        {
            IDbConnection connection = DBUtils.getConnection(props);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update Oficii set id=@id, password=@password where id=@idO";

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.ID;
                command.Parameters.Add(paramId);

                var paramNume = command.CreateParameter();
                paramNume.ParameterName = "@password";
                paramNume.Value = entity.Password;
                command.Parameters.Add(paramNume);

                var paramIdO = command.CreateParameter();
                paramIdO.ParameterName = "@idO";
                paramIdO.Value = id;
                command.Parameters.Add(paramIdO);

                command.ExecuteNonQuery();
            }
        }

        
    }
}
