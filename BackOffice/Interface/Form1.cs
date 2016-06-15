using BackOffice.Business;
using BackOffice.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;

namespace BackOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            percursosDAO dao = new percursosDAO();
            utilizadoresDAO uDAO = new utilizadoresDAO();

            try
            {
                Bitmap foto = new Bitmap(300, 200);
                byte[] foto_bytes = registo.imageToByteArray(foto);
                string foto_string = Convert.ToBase64String(foto_bytes);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("sessao.gp"))
                {
                    sw.Write(foto_string);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
