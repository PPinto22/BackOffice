using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOffice.DAO;

namespace BackOffice.Interface
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signUp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string eMail = textBox1.Text;
            string nome = textBox3.Text;
            string password = textBox2.Text;

            utilizadoresDAO connection = new utilizadoresDAO();
            if (eMail.Equals("") || nome.Equals("") || password.Equals("")) MessageBox.Show("Existem campos por preencher.");
            else
            {
                if (connection.contains(eMail))
                {
                    MessageBox.Show("O e-mail indicado já foi registado.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else if (IsValidEmail(eMail))
                {
                    connection.add(new Business.utilizador(eMail, nome, password));
                    this.Close();
                    MessageBox.Show("Registo efetuado com sucesso!");
                }
                else MessageBox.Show("E-mail não válido.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
