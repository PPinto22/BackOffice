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
    public partial class Form1 : Form
    {
        public GMapOverlay markersOverlay;
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
            /*markersOverlay = new GMapOverlay("markers");
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker1 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(41.55559515, -8.3971316), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker2 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(45.55559515, -8.3971316), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker3 = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(42.55559515, -6.3971316), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green);
            markersOverlay.Markers.Add(marker1);
            markersOverlay.Markers.Add(marker2);
            markersOverlay.Markers.Add(marker3);
            gMapControl1.Overlays.Add(markersOverlay);*/

        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
        }
    }
}
