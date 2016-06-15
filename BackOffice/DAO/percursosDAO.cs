using BackOffice.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;


namespace BackOffice.DAO
{
    public class percursosDAO
    {
        public percursosDAO() { }

        public HashSet<PointLatLng> getCoordenadas()
        {
            HashSet<PointLatLng> coordenadas = new HashSet<PointLatLng>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select latitude, longitude from Atividades";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                double latitude = reader.GetDouble(0);
                double longitude = reader.GetDouble(1);
                PointLatLng ponto = new PointLatLng(latitude, longitude);

                coordenadas.Add(ponto);
            }

            myConnection.Close();

            return coordenadas;
        }

        public bool contains(percurso p)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);
            bool contains;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos where data = @p0 and utilizador = @p1";
            cmd.Parameters.AddWithValue("@p0", p.data);
            cmd.Parameters.AddWithValue("@p1", p.utilizador);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            contains = reader.HasRows;

            myConnection.Close();

            return contains;
        }

        public List<percurso> getAll()
        {
            List<percurso> percursos = new List<percurso>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email = reader.GetString(2).Trim();

                percurso p = new percurso(data, email, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public List<percurso> getAllByDate(DateTime inicio, DateTime fim)
        {
            List<percurso> percursos = new List<percurso>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos where data > @p1 and data < @p2";
            cmd.Parameters.AddWithValue("@p1", inicio);
            cmd.Parameters.AddWithValue("@p2", fim);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email = reader.GetString(2).Trim();

                percurso p = new percurso(data, email, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public List<percurso> getAllByDateAndUser(DateTime inicio, DateTime fim, string email)
        {
            List<percurso> percursos = new List<percurso>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos where data > @p1 and data < @p2 and utilizador = @p3";
            cmd.Parameters.AddWithValue("@p1", inicio);
            cmd.Parameters.AddWithValue("@p2", fim);
            cmd.Parameters.AddWithValue("@p3", email);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email2 = reader.GetString(2).Trim();

                percurso p = new percurso(data, email2, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public List<percurso> getAllByDateAndUsers(DateTime inicio, DateTime fim, List<string> emails)
        {
            List<percurso> percursos = new List<percurso>();
            if (emails.Count == 0) return percursos;

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Percursos where data > @di and data < @df and utilizador in (@p0");
            cmd.Parameters.AddWithValue("@di", inicio);
            cmd.Parameters.AddWithValue("@df", fim);
            for (int i = 1; i < emails.Count; i++)
            {
                sb.Append(", @p" + i);
            }
            sb.Append(")");
            cmd.CommandText = sb.ToString();
            for (int i = 0; i < emails.Count; i++)
            {
                cmd.Parameters.AddWithValue("@p" + i, emails[i]);
            }
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email2 = reader.GetString(2).Trim();

                percurso p = new percurso(data, email2, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public List<percurso> getAllByUsers(List<string> emails)
        {
            List<percurso> percursos = new List<percurso>();
            if (emails.Count == 0) return percursos;

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Percursos where utilizador in (@p0");
            for(int i = 1; i<emails.Count; i++)
            {
                sb.Append(", @p"+i);
            }
            sb.Append(")");
            cmd.CommandText = sb.ToString();
            for (int i = 0; i < emails.Count; i++)
            {
                cmd.Parameters.AddWithValue("@p"+i, emails[i]);
            }
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email2 = reader.GetString(2).Trim();

                percurso p = new percurso(data, email2, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public List<percurso> getAllByUser(string email)
        {
            List<percurso> percursos = new List<percurso>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos where utilizador = @p1";
            cmd.Parameters.AddWithValue("@p1", email);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email2 = reader.GetString(2).Trim();

                percurso p = new percurso(data, email2, id);
                percursos.Add(p);
            }

            myConnection.Close();

            return percursos;
        }

        public percurso get(int idPercurso)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Percursos where id = @p1";
            cmd.Parameters.AddWithValue("p1", idPercurso);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            percurso p = null;

            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime data = reader.GetDateTime(1);
                string email = reader.GetString(2).Trim();

                p = new percurso(data, email, id);
            }

            myConnection.Close();

            return p;
        }

        public bool add(percurso p)
        {
            if (this.contains(p)) return false;

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Percursos (data, utilizador) output INSERTED.ID values (@p0,@p1)";
            cmd.Parameters.AddWithValue("@p0", p.data);
            cmd.Parameters.AddWithValue("@p1", p.utilizador);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();
            int lastID = (int)cmd.ExecuteScalar();

            myConnection.Close();

            p.atividadesDAO = new atividadesDAO(lastID);
            foreach(atividade a in p.atividades)
            {
                p.atividadesDAO.add(a);
            }

            return true;
        }

        public bool remove(percurso p)
        {
            if (!this.contains(p)) return false;

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from Percursos where data = @p0 and utilizador = @p1";
            cmd.Parameters.AddWithValue("@p0", p.data);
            cmd.Parameters.AddWithValue("@p1", p.utilizador);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();
            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
