using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOffice.Business;
using BackOffice.DAO;

namespace BackOffice.Interface
{
    public partial class Form3 : Form
    {
        public List<utilizador> utilizadores { get; set;}
        public DateTime dataInicio { get; set;}
        public DateTime dataFim { get; set;}
        public List<percurso> percursos { get; set;}
        public percursosDAO conn1;

        public Form3()
        {
            this.dataInicio = new DateTime();
            this.dataFim = new DateTime();
            
            InitializeComponent();
            MessageBox.Show("asd");
            conn1 = new percursosDAO();
            this.percursos = conn1.getAll();
            this.refresh();
            //--------
            utilizadoresDAO conn2 = new utilizadoresDAO();
            this.utilizadores = conn2.getUsers();
            for(int i = 0; i<utilizadores.Count; i++)
            {
                this.checkedListBox1.Items.Add(utilizadores[i].email);
            }
            button1.Enabled = false;
            button2.Enabled = false;
            checkedListBox1.Enabled = false;
           
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new Form4())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DateTime date = form.data;
                    //Do something here with these values

                    //for example
                    this.dataInicio = date;
                    this.label4.Text = this.dataInicio.ToShortDateString();
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkedListBox1.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new Form4())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DateTime date = form.data;
                    //Do something here with these values

                    //for example
                    this.dataFim = date;
                    this.label5.Text = this.dataFim.ToShortDateString();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    List<string> utilizadores_selecionados = new List<string>();

                    foreach (object a in checkedListBox1.CheckedItems)
                    {
                        utilizadores_selecionados.Add(a.ToString());
                    }
                    this.percursos = conn1.getAllByDateAndUsers(this.dataInicio, this.dataFim, utilizadores_selecionados);
                    this.refresh();
                }
                else
                {
                    List<string> utilizadores_selecionados = new List<string>();

                    foreach (object a in checkedListBox1.CheckedItems)
                    {
                        utilizadores_selecionados.Add(a.ToString());
                    }
                    this.percursos = conn1.getAllByUsers(utilizadores_selecionados);
                    this.refresh();
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    this.percursos = conn1.getAllByDate(this.dataInicio, this.dataFim);
                    this.refresh();
                }
                else
                {
                    this.percursos = conn1.getAll();
                    this.refresh();
                }
            }
        }
        private void refresh()
        {
            listView1.Items.Clear();   
            for (int i = 0; i < percursos.Count; i++)
            {
                ListViewItem l = new ListViewItem(percursos[i].data.ToShortDateString());
                l.SubItems.Add(percursos[i].utilizador);
                
                this.listView1.Items.Add(l);
            }
        }
    }
}
