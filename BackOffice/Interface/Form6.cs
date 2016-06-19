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
    public partial class Mapa : Form
    {
        public GMapOverlay markersOverlay;
        public Mapa(PointLatLng p)
        {
            InitializeComponent();
            gMapControl3.DragButton = MouseButtons.Left;
            gMapControl3.CanDragMap = true;
            gMapControl3.MapProvider = GMapProviders.GoogleMap;
            gMapControl3.Position = new PointLatLng(41.55559515, -8.3971316);
            gMapControl3.MinZoom = 0;
            gMapControl3.MaxZoom = 24;
            gMapControl3.Zoom = 9;
            gMapControl3.AutoScroll = true;

            this.markersOverlay = new GMapOverlay("markers");
            GMap.NET.WindowsForms.Markers.GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            gMapControl3.Overlays.Add(markersOverlay);
        }

        private void Mapa_Load(object sender, EventArgs e)
        {

        }
    }
}
