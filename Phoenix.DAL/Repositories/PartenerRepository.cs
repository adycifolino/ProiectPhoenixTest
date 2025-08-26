using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Phoenix.DAL.Entities;
using Phoenix.DAL.Interfaces;

namespace Phoenix.DAL.Repositories
{
    public class PartenerRepository:IPartenerRepository
    {
        private readonly string _connectionString;
        public PartenerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PartenerEntity> GetAll()
        {
            var lista = new List<PartenerEntity>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT Id, Denumire FROM tblPartener", conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new PartenerEntity
                    {
                        Id = (int)reader["Id"],
                        Denumire = reader["Denumire"] as string ?? string.Empty
                    });
                }
            }
            return lista;
        }

        public PartenerEntity GetById(int id)
        {
            PartenerEntity p = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT Id, Denumire FROM tblPartener WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    p = new PartenerEntity
                    {
                        Id = (int)reader["Id"],
                        Denumire = reader["Denumire"] as string ?? string.Empty
                    };
                }
            }
            return p;
        }

        public void Add(PartenerEntity p)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO tblPartener (Denumire) VALUES (@denumire)", conn);
                cmd.Parameters.AddWithValue("@denumire", p.Denumire);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PartenerEntity p)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE tblPartener SET Denumire = @denumire WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@denumire", p.Denumire);
                cmd.Parameters.AddWithValue("@id", p.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM tblPartener WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
