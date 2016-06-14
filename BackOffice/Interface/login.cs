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
using BackOffice.Business;

namespace BackOffice
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            this.textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {   

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eMail = textBox1.Text;
            string pass = textBox2.Text;
            
            utilizadoresDAO connection = new utilizadoresDAO();

            if (connection.contains(eMail))
            {
                utilizador user = connection.get(eMail);
                if (user.password.Equals(pass))
                {
                    Interface.Form1 menu_inicial = (new BackOffice.Interface.Form1(user));
                    menu_inicial.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password incorreta!");
                    textBox2.Clear();
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Interface.signUp menu_inicial = (new BackOffice.Interface.signUp());
            menu_inicial.ShowDialog();
        }
    }
}
