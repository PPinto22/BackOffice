using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using GMap.NET;
using System.IO;
using System.Windows.Forms;

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
            if(a.registo.voz != null)
            {
                cmd = new SqlCommand();
                cmd.CommandText = @"insert into Gravacoes (voz,traducao,registo)
                                    values (@p0,@p1,@p2)";
                cmd.Parameters.AddWithValue("@p0", a.registo.voz);
                cmd.Parameters.AddWithValue("@p1", a.registo.traducao);
                cmd.Parameters.AddWithValue("@p2", registoID);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
            }

            // Inserir em Rochas/Minerais
            if(a.registo.tipo == registo.ROCHA)
            {
                rocha rocha = a.registo.rocha;
                cmd = new SqlCommand();
                cmd.CommandText = @"insert into Rochas (tipo,textura,designacao,cor,registo,peso)
                                    values (@tipo,@textura,@designacao,@cor,@registo,@peso)";
                cmd.Parameters.AddWithValue("@tipo", rocha.tipo);
                cmd.Parameters.AddWithValue("@textura", rocha.textura);
                cmd.Parameters.AddWithValue("@designacao", rocha.designacao);
                cmd.Parameters.AddWithValue("@cor", rocha.cor);
                cmd.Parameters.AddWithValue("@registo", registoID);
                cmd.Parameters.AddWithValue("@peso", rocha.peso);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
            }
            else if(a.registo.tipo == registo.MINERAL)
            {
                mineral mineral = a.registo.mineral;
                cmd = new SqlCommand();
                cmd.CommandText = @"insert into Minerais (risca,cor,designacao,peso,registo)
                                    values (@risca,@cor,@designacao,@peso,@registo)";
                cmd.Parameters.AddWithValue("@risca", mineral.risca);
                cmd.Parameters.AddWithValue("@cor", mineral.cor);
                cmd.Parameters.AddWithValue("@designacao", mineral.designacao);
                cmd.Parameters.AddWithValue("@peso", mineral.peso);
                cmd.Parameters.AddWithValue("@registo", registoID);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
            }

            myConnection.Close();

            return true;
        }

        public List<atividade> getAtividades()
        {
            List<atividade> la = new List<atividade>();

            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Atividades where percurso = @p1";
            cmd.Parameters.AddWithValue("@p1", this.idPercurso);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);

                double latitude = reader.GetDouble(1);

                double longitude = reader.GetDouble(2);

                PointLatLng ponto = new PointLatLng(latitude, longitude);

                string notas = reader.GetString(3).Trim();
                string objetivos = reader.GetString(4).Trim();
                int percurso = reader.GetInt32(5);

                atividade a = new atividade(ponto, objetivos, notas, null);

                SqlConnection myConnection2 = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);
                

                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "select * from Registos where atividade = @p1";
                cmd2.Parameters.AddWithValue("@p1", id);
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = myConnection2;
                myConnection2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();

                reader2.Read();
                
                int registoid = reader2.GetInt32(0);
                myConnection2.Close();

                SqlConnection myConnection3 = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "select * from Fotografias where registo = @p1";
                cmd3.Parameters.AddWithValue("@p1", registoid);
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = myConnection3;

                myConnection3.Open();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                
                List<Bitmap> fotos = new List<Bitmap>();
                Bitmap foto = null;
                if (reader3.Read())
                {
                    byte[] bytesFoto = (byte[])reader3[1];
                    foto = (Bitmap)registo.byteArrayToImage(bytesFoto);
                    fotos.Add(foto);
                }
                myConnection3.Close();

                byte[] voz = null;
                SqlConnection myConnection6 = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);
                SqlCommand cmd6 = new SqlCommand();
                cmd6.CommandText = "select * from Gravacoes where registo = @p1";
                cmd6.Parameters.AddWithValue("@p1", registoid);
                cmd6.CommandType = CommandType.Text;
                cmd6.Connection = myConnection6;

                myConnection6.Open();
                SqlDataReader reader6 = cmd6.ExecuteReader();

                string traducao = string.Empty;

                if (reader6.Read())
                {
                    voz = (byte[])reader6[1];
                    traducao = reader6.GetString(2).Trim();
                    
                }
                registo reg = new registo(fotos, voz, traducao);
                myConnection6.Close();

                SqlConnection myConnection4 = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);
                
                SqlCommand cmd4 = new SqlCommand();
                cmd4.CommandText = "select * from Rochas where registo = @p1";
                cmd4.Parameters.AddWithValue("@p1", registoid);
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = myConnection4;

                myConnection4.Open();
                
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    int idRocha = reader4.GetInt32(0);
                   
                    string tipoRocha = reader4.GetString(1).Trim();
                    string texturaRocha = reader4.GetString(2).Trim();
                    string designacaoRocha = reader4.GetString(3).Trim();
                    string corRocha = reader4.GetString(4).Trim();
                    float pesoRocha = (float)reader4.GetDouble(6);
                    rocha rocha = new rocha(designacaoRocha, tipoRocha, pesoRocha, texturaRocha, corRocha);
                    reg.setRocha(rocha);
                }

                myConnection4.Close();
                SqlConnection myConnection5 = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);
                
                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = "select * from Minerais where registo = @p1";
                cmd5.Parameters.AddWithValue("@p1", registoid);
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = myConnection5;

                myConnection5.Open();

                SqlDataReader reader5 = cmd5.ExecuteReader();

                if (reader5.Read())
                {
                    int idMineral = reader5.GetInt32(0);
                    string riscaMineral = reader5.GetString(1).Trim();
                    string corMineral = reader5.GetString(2).Trim();
                    string designacaoMineral = reader5.GetString(3).Trim();
                    float pesoMineral = (float)reader5.GetDouble(4);
                    mineral mineral = new mineral(designacaoMineral, pesoMineral, riscaMineral, corMineral);
                    reg.setMineral(mineral);
                }

                myConnection5.Close();
                a.registo = reg;
                la.Add(a);

            }
            myConnection.Close();

            return la;
        }
    }
}