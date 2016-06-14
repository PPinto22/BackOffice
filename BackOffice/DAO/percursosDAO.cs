using BackOffice.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.DAO
{
    public class percursosDAO
    {
        public percursosDAO() { }

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
                // TODO
            }

            myConnection.Close();

            return percursos;
        }
    }
}
