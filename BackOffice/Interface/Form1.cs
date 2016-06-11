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
            utilizadoresDAO dao = new utilizadoresDAO();

            try
            {
                utilizador u = new utilizador("teste2", "pass2", "alberto teste 2");
                if (dao.add(u))
                {
                    MessageBox.Show("Sucesso");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
