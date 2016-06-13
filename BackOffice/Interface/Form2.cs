using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace BackOffice.Interface
{
    public partial class add_percurso : Form
    {
        int atividades_uteis = 1;
        public GMapOverlay markersOverlay;
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

            markersOverlay = new GMapOverlay("markers");
        }

        private void mouse_click2(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (atividades_uteis!=0) {
            int x = e.Location.X;
            int y = e.Location.Y;
            PointLatLng p = new PointLatLng();
            p = gMapControl2.FromLocalToLatLng(x, y);
            GMap.NET.WindowsForms.Markers.GMarkerGoogle penis = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
            markersOverlay.Markers.Add(penis);
            gMapControl2.Overlays.Add(markersOverlay);
            double currentZoom = gMapControl2.Zoom;
            gMapControl2.Zoom = 9.1;
            gMapControl2.Zoom = currentZoom;
            }
            this.atividades_uteis = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 2;
            PointLatLng p = new PointLatLng(51.64828831,-8.12164307);
            //p = gMapControl2.FromLocalToLatLng(x, y);
            GMap.NET.WindowsForms.Markers.GMarkerGoogle penis = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
            markersOverlay.Markers.Add(penis);
            gMapControl2.Overlays.Add(markersOverlay);
        }

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
                listBox1.Items.Add(website);
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
            richTextBox1.Clear();
            richTextBox2.Clear();
            listBox1.Items.Clear();
            textBox1.Clear();
            atividades_uteis = 1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
