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
using System.Media;
using System.Speech.Recognition;
using System.Speech.AudioFormat;

namespace BackOffice.Interface
{
    public partial class Form5 : Form
    {
        public percurso percurso { get; set; }
        public int currentActivity {get; set;}
        public byte[] voz;
        SoundPlayer simpleSound;
        private string voz_path;
        public Form5()
        {
            this.currentActivity = 0;
            InitializeComponent();
        }

        public Form5(percurso p)
        {
            this.voz = null;
            this.simpleSound = null;
            this.currentActivity = 0;
            this.percurso = p;
            InitializeComponent();
            this.FormClosing += Form5_FormClosing;
            if (this.percurso.atividades[currentActivity].registo.tipo == registo.ROCHA)
            {
                
                formRocha();
            }
            else if (this.percurso.atividades[currentActivity].registo.tipo == registo.MINERAL)
            {
                formMineral();
            }

            byte[] bytes = this.percurso.atividades[currentActivity].registo.voz;
            if (bytes == null)
            {
                textBox1.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                this.voz = bytes;
                System.IO.File.WriteAllBytes("voz.wav", bytes);
                this.voz_path = Directory.GetCurrentDirectory() + "\\voz.wav";
                simpleSound = new SoundPlayer("voz.wav");
            }
            try
            {
                SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("pt-PT"));
                Grammar dictationGrammar = new DictationGrammar();
                recognizer.LoadGrammar(dictationGrammar);
                recognizer.SetInputToAudioStream(File.OpenRead(Directory.GetCurrentDirectory() + "\\voz.wav"), new System.Speech.AudioFormat.SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
                RecognitionResult result = recognizer.Recognize();
                this.textBox1.Text = result.ToString();
            }
            catch { }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(this.voz_path))
            {
                File.Delete(this.voz_path);
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
            this.label4.Text = "Designação";
            this.label5.Text = "Tipo";
            this.label6.Text = "Peso (Kg)";
            this.label7.Text = "Textura";
            this.label8.Text = "Cor";
            this.label1.Text = "Atividade nº" + (this.currentActivity + 1).ToString();
            //this.label3.Text = this.percurso.atividades[currentActivity].coordenadas.ToString();
            this.label9.Text = this.percurso.atividades[currentActivity].registo.rocha.designacao.ToString();
            this.label10.Text = this.percurso.atividades[currentActivity].registo.rocha.tipo.ToString();
            this.label11.Text = this.percurso.atividades[currentActivity].registo.rocha.peso.ToString();
            this.label12.Text = this.percurso.atividades[currentActivity].registo.rocha.textura.ToString();
            this.label13.Text = this.percurso.atividades[currentActivity].registo.rocha.cor.ToString();
            this.label8.Show();
            this.label13.Show();
            this.label14.Text = "Rocha";
            this.label16.Text = this.percurso.atividades[currentActivity].coordenadas.Lat.ToString();
            this.label17.Text = this.percurso.atividades[currentActivity].coordenadas.Lng.ToString();

            if (this.percurso.atividades[currentActivity].registo.fotos.Count()!=0) { 
                Bitmap imagem = this.percurso.atividades[currentActivity].registo.fotos[0];
                Bitmap resized = new Bitmap(imagem, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
                this.pictureBox1.Image = resized;
            }
            else
            {
                Image image;
                image = Image.FromFile("no-photo.png");
                Image resized = (Image)(new Bitmap(image,this.pictureBox1.Width,this.pictureBox1.Height));
                this.pictureBox1.Image = resized;
            }
        }

        private void formMineral()
        {
            this.label1.Text = "Atividade nº" + (this.currentActivity + 1).ToString();
            this.label4.Text = "Designação";
            this.label5.Text = "Risca";
            this.label6.Text = "Peso (Kg)";
            this.label7.Text = "Cor";
            this.label8.Hide();
            this.label13.Hide();
            this.label9.Text = this.percurso.atividades[currentActivity].registo.mineral.designacao;
            this.label10.Text = this.percurso.atividades[currentActivity].registo.mineral.risca;
            this.label11.Text = this.percurso.atividades[currentActivity].registo.mineral.peso.ToString();
            this.label12.Text = this.percurso.atividades[currentActivity].registo.mineral.cor;
            this.label14.Text = "Mineral";
            this.label16.Text = this.percurso.atividades[currentActivity].coordenadas.Lat.ToString();
            this.label17.Text = this.percurso.atividades[currentActivity].coordenadas.Lng.ToString();

            Bitmap imagem = this.percurso.atividades[currentActivity].registo.fotos[0];

            Bitmap resized = new Bitmap(imagem, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
            this.pictureBox1.Image = resized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.currentActivity == (this.percurso.atividades.Count) - 1)
            {
                ;
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
               ;
            }
            else
            {
                currentActivity--;

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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            simpleSound.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mapa mapa = new Mapa(this.percurso.atividades[currentActivity].coordenadas);
            mapa.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
