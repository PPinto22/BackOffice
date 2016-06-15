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
using BackOffice.Business;
using System.IO;
using System.Xml;

namespace BackOffice.Interface
{
    public partial class Form1 : Form
    {
        public GMapOverlay markersOverlay;
        public utilizador user;
        public List<percurso> percursos;

        public Form1(utilizador u)
        {
            InitializeComponent();
            this.Text = "Utilizador: " + u.nome;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(41.55559515, -8.3971316);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click);


            this.markersOverlay = new GMapOverlay("markers");
            this.user = u;
            this.percursos = new List<percurso>();
        }

        public Form1()
        {
            InitializeComponent();
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(41.55559515, -8.3971316);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click);


            markersOverlay = new GMapOverlay("markers");
        }
        
        private void mouse_click(object sender,System.Windows.Forms.MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            PointLatLng p = new PointLatLng();
            p = gMapControl1.FromLocalToLatLng(x, y);
            MessageBox.Show(p.ToString());
            GMap.NET.WindowsForms.Markers.GMarkerGoogle penis = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
            markersOverlay.Markers.Add(penis);
            gMapControl1.Overlays.Add(markersOverlay);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Business.percurso p = new Business.percurso();
            Interface.add_percurso add_percurso = (new BackOffice.Interface.add_percurso(p));
            add_percurso.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    XmlDocument xml_lido = new XmlDocument();
                    xml_lido.Load(text);
                    percurso p = percurso.readXML(xml_lido,this.user.email);
                    BackOffice.DAO.percursosDAO conn = new BackOffice.DAO.percursosDAO();
                    conn.add(p);
                    MessageBox.Show("Sessão carregada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
