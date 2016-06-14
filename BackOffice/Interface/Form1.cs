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
                List<percurso> percursos = dao.getAll();
                foreach(percurso p in percursos)
                {
                    dao.remove(p);
                    MessageBox.Show("remove: " + p.data.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
