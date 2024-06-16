using DemoExam.Repository;
using MaiProject.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MaiProject.Repository
{
    public class PositionRepository : Repository<Position>
    {
        public override int Add(Position item)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Position item)
        {
            throw new System.NotImplementedException();
        }

        public override List<Position> GetAll()
        {
            var query = "SELECT * FROM [Должности]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            var positions = new List<Position>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);

                var position = new Position(id, name);
                positions.Add(position);
            }
            reader.Close();
            connection.Close();
            return positions;
        }

        public override Position GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(Position item)
        {
            throw new System.NotImplementedException();
        }
    }
}
