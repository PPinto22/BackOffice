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
using System.Data.SqlClient;


namespace BackOffice.Interface
{
    public partial class Form1 : Form
    {
        public GMapOverlay markersOverlay;
        public utilizador user;
        public HashSet<PointLatLng> coordenadas;
        public BackOffice.DAO.percursosDAO conn;

        public Form1(utilizador u)
        {
            conn = new BackOffice.DAO.percursosDAO();
            this.coordenadas = conn.getCoordenadas();
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
            //gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click);


            this.markersOverlay = new GMapOverlay("markers");
            foreach(PointLatLng p in coordenadas) {  
                GMap.NET.WindowsForms.Markers.GMarkerGoogle penis = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                markersOverlay.Markers.Add(penis);
            }
            gMapControl1.Overlays.Add(markersOverlay);

            this.user = u;
            this.FormClosing+= Form1_Closing;
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
            //gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouse_click);


            markersOverlay = new GMapOverlay("markers");
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Business.percurso p = new Business.percurso();
            Interface.add_percurso add_percurso = (new BackOffice.Interface.add_percurso(p));
            add_percurso.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    
                    XmlDocument xml_lido = new XmlDocument();
                    xml_lido.Load(file);
                    percurso p = percurso.readXML(xml_lido,this.user.email);
                    BackOffice.DAO.percursosDAO conn = new BackOffice.DAO.percursosDAO();
                    if(conn.add(p))
                    MessageBox.Show("Sessão carregada com sucesso!");
                    else { MessageBox.Show("Percurso já existente!"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            /*
            SqlConnection myConnection = new SqlConnection(Properties.Resources.DB_CONNECTION_STRING);

            string myImage = "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";
            byte[] byteBuffer = Convert.FromBase64String(myImage);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Fotografias(foto,registo) values (@p0,2)";
            cmd.Parameters.AddWithValue("@p0", byteBuffer);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            myConnection.Open();
            cmd.ExecuteNonQuery();*/
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void refresh()
        {
            conn = new BackOffice.DAO.percursosDAO();
            this.coordenadas = conn.getCoordenadas();

            this.markersOverlay = new GMapOverlay("markers");
            foreach (PointLatLng p in coordenadas)
            {
                GMap.NET.WindowsForms.Markers.GMarkerGoogle penis = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                markersOverlay.Markers.Add(penis);
            }
            gMapControl1.Overlays.Add(markersOverlay);
        }
    }
}
