using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BackOffice.Business;

namespace BackOffice.Interface
{
    public partial class Form5 : Form
    {
        public percurso percurso { get; set; }
        public int currentActivity {get; set;}
        public Form5()
        {
            this.currentActivity = 0;
            InitializeComponent();
        }

        public Form5(percurso p)
        {
            this.currentActivity = 0;
            this.percurso = p;
            InitializeComponent();
            
            if (this.percurso.atividades[currentActivity].registo.tipo == 0)
            {
                formRocha();
            }
            else
            {
                formMineral();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void formRocha()
        {
            this.label1.Text = "Atividade nº" + (this.currentActivity + 1).ToString();
            this.label3.Text = this.percurso.atividades[currentActivity].coordenadas.ToString();
            this.label8.Hide();
            this.label13.Hide();
            
            /*byte[] byteBuffer = Convert.FromBase64String(myImage);

            Image penis = BackOffice.Business.registo.byteArrayToImage(byteBuffer);

            byteBuffer = null;*/

            Bitmap imagem = this.percurso.atividades[currentActivity].registo.fotos[0];

            Bitmap resized = new Bitmap(imagem, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
            this.pictureBox1.Image = resized;
        }
        private void formMineral()
        {
            this.label1.Text = "Atividade nº" + (this.currentActivity + 1).ToString();
            this.label5.Text = "Risca";
            this.label7.Text = "Cor";
            this.label8.Hide();
            this.label9.Text = this.percurso.atividades[currentActivity].registo.mineral.designacao;
            this.label10.Text = this.percurso.atividades[currentActivity].registo.mineral.risca;
            this.label11.Text = this.percurso.atividades[currentActivity].registo.mineral.peso.ToString();
            this.label12.Text = this.percurso.atividades[currentActivity].registo.mineral.cor;

            Bitmap imagem = this.percurso.atividades[currentActivity].registo.fotos[0];

            Bitmap resized = new Bitmap(imagem, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
            this.pictureBox1.Image = resized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.currentActivity == (this.percurso.atividades.Count) - 1)
            {
                MessageBox.Show("Não existem mais atividades");
            }
            else
            {
                currentActivity++;

                if (this.percurso.atividades[currentActivity].registo.tipo == 0)
                {
                    formRocha();
                }
                else
                {
                    formMineral();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.currentActivity == 0)
            {
                MessageBox.Show("Não existem atividades anteriores.");
            }
            else
            {
                currentActivity++;

                if (this.percurso.atividades[currentActivity].registo.tipo == 0)
                {
                    formRocha();
                }
                else
                {
                    formMineral();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
