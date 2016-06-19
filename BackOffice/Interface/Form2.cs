using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using BackOffice.Business;

namespace BackOffice.Interface
{
    public partial class add_percurso : Form
    {
        public int atividades_uteis = 1;
        private bool ponto_colocado = false;
        public percurso percurso;
        public GMapOverlay markersOverlay;
        //public List<PointLatLng> pontos;
        public PointLatLng ultimoPonto;
        public string objetivos;
        public string notas;
        public List<string> websites;
        public GMap.NET.WindowsForms.Markers.GMarkerGoogle marker;

        public add_percurso()
        {
            InitializeComponent();
            gMapControl2.DragButton = MouseButtons.Left;
            gMapControl2.CanDragMap = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            gMapControl2.Position = new PointLatLng(41.55559515, -8.3971316);
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;
            gMapControl2.Zoom = 9;
            gMapControl2.AutoScroll = true;
            gMapControl2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;

            this.markersOverlay = new GMapOverlay("markers");

            this.percurso = new percurso();
            //this.pontos = new List<PointLatLng>();
            this.ultimoPonto = new PointLatLng();
            this.objetivos = string.Empty;
            this.notas = string.Empty;
            this.websites = new List<string>();

        }

        public add_percurso(percurso p)
        {
            InitializeComponent();
            gMapControl2.DragButton = MouseButtons.Left;
            gMapControl2.CanDragMap = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            gMapControl2.Position = new PointLatLng(41.55559515, -8.3971316);
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;
            gMapControl2.Zoom = 9;
            gMapControl2.AutoScroll = true;
            gMapControl2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;

            markersOverlay = new GMapOverlay("markers");

            this.percurso = p;
            //this.pontos = new List<PointLatLng>();
            this.ultimoPonto = new PointLatLng();
            this.objetivos = string.Empty;
            this.notas = string.Empty;
            this.websites = new List<string>();
        }

        private void mouse_click2(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int x, y;
            if (this.ponto_colocado)
            {

                markersOverlay.Markers.Remove(marker);
                x = e.Location.X;
                y = e.Location.Y;
                this.ultimoPonto = new PointLatLng();
                this.ultimoPonto = gMapControl2.FromLocalToLatLng(x, y);
                marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(this.ultimoPonto, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                this.markersOverlay.Markers.Add(marker);
                gMapControl2.Overlays.Add(markersOverlay);
                double currentZoom = gMapControl2.Zoom;
                gMapControl2.Zoom = currentZoom+0.1;
                gMapControl2.Zoom = currentZoom;
                this.ponto_colocado = true;
            }
            else
            {
                x = e.Location.X;
                y = e.Location.Y;
                this.ultimoPonto = new PointLatLng();
                this.ultimoPonto = gMapControl2.FromLocalToLatLng(x, y);
                marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(this.ultimoPonto, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                markersOverlay.Markers.Add(marker);
                gMapControl2.Overlays.Add(markersOverlay);
                double currentZoom = gMapControl2.Zoom;
                gMapControl2.Zoom = currentZoom+0.1;
                gMapControl2.Zoom = currentZoom;
                this.ponto_colocado = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.objetivos = richTextBox1.Text;
        //    this.notas = richTextBox2.Text;

        //    atividade a = new atividade(this.point, this.objetivos, this.notas, this.websites);
        //    this.percurso.addAtividade(a);
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_percurso_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string website = textBox1.Text;
            if (website != "")  {
                if (listBox1.Items.Contains("http://"+website) || listBox1.Items.Contains(website))
                {
                    MessageBox.Show("Website já foi inserido.");
                }
                else {
                    using (WebClient client = new WebClient())
                    {

                        try
                        {
                            if (!website.StartsWith("http://")) website = "http://" + website;
                            string htmlCode = client.DownloadString(website);
                            listBox1.Items.Add(website);
                            this.websites.Add(website);
                        }
                        catch
                        {
                            MessageBox.Show("Website inválido.");
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.objetivos = richTextBox1.Text;
            this.notas = richTextBox2.Text;
            if (this.ponto_colocado)
            {
                atividade a = new atividade(this.ultimoPonto, this.objetivos, this.notas, this.websites);
                percurso.addAtividade(a);
                richTextBox1.Clear();
                richTextBox2.Clear();
                listBox1.Items.Clear();
                textBox1.Clear();
                atividades_uteis = 1;
                this.websites = new List<string>();
                this.ponto_colocado = false;
            }
            else
            {
                MessageBox.Show("Indique no mapa o local pretendido para a atividade.");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.percurso.atividades.Count == 0)
            {
                MessageBox.Show("Não inseriu nenhuma atividade.");
            }
            else
            {
                saveFileDialog1.DefaultExt = ".gp";
                saveFileDialog1.FileName = "percurso";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string xml_gerado = this.percurso.writeXML();
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.FileName))
                    {
                        sw.WriteLine(xml_gerado);
                        MessageBox.Show("Percurso criado com sucesso!");
                        this.Close();
                    }
                }
                
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
