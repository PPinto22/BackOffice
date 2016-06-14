using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace BackOffice.Business
{
    public class atividadesDAO
    {
        private int idPercurso;

        public atividadesDAO(int idPercurso)
        {
            this.idPercurso = idPercurso;
        }

        public bool add(atividade a)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            // Inserir em Atividades
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"insert into Atividades (latitude, longitude, notas, objetivos, percurso)
                                output INSERTED.ID values (@p0,@p1,@p2,@p3,@p4)";
            cmd.Parameters.AddWithValue("@p0", a.coordenadas.Lat);
            cmd.Parameters.AddWithValue("@p1", a.coordenadas.Lng);
            cmd.Parameters.AddWithValue("@p2", a.notas);
            cmd.Parameters.AddWithValue("@p3", a.objetivos);
            cmd.Parameters.AddWithValue("@p4", this.idPercurso);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();
            int atividadeID = (int)cmd.ExecuteScalar();

            // Inserir em Registos
            cmd = new SqlCommand();
            cmd.CommandText = @"insert into Registos (atividade) output INSERTED.ID
                                values (@p0)";
            cmd.Parameters.AddWithValue("@p0", atividadeID);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;
            int registoID = (int)cmd.ExecuteScalar();

            registo reg = a.registo;

            // Inserir em Fotografias
            List<Bitmap> fotos = reg.fotos;
            if (fotos.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Fotografias (foto, registo) values ");
                sb.Append("(@p0,@reg)");
                for(int i = 1; i<fotos.Count; i++)
                {
                    sb.Append(",(@p" + i + ",@reg)");
                }
                cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = myConnection;
                cmd.Parameters.AddWithValue("@reg", registoID);
                for(int i  = 0; i < fotos.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@p" + i, registo.imageToByteArray(fotos[i]));
                }

                cmd.ExecuteNonQuery();
            }

            // Inserir em Gravacoes
            // TODO ...

            // Inserir em Rochas/Minerais
            // TODO ...

            myConnection.Close();

            return true;
        }
    }
}