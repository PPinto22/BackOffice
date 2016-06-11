using BackOffice.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.DAO
{
    class utilizadoresDAO
    {
        public utilizadoresDAO() { }

        public bool contains(string email)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Utilizadores where email = @p1";
            cmd.Parameters.AddWithValue("@p1", email);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            bool contains = reader.HasRows;
            myConnection.Close();


            return contains;
        }

        public utilizador get(string email)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Utilizadores where email = @p1";
            cmd.Parameters.AddWithValue("@p1", email);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            utilizador utl = null;

            if (reader.HasRows)
            {
                reader.Read();
                utl = new utilizador(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }

            myConnection.Close();

            return utl;
        }

        public bool add(utilizador u)
        {
            if (this.contains(u.email)) return false;

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Utilizadores (email, password, nome) values(@p1,@p2,@p3)";
            cmd.Parameters.AddWithValue("@p1", u.email);
            cmd.Parameters.AddWithValue("@p2", u.password);
            cmd.Parameters.AddWithValue("@p3", u.nome);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();
            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
