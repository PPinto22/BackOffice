namespace BackOffice.Interface
{
    partial class Mapa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl3 = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // gMapControl3
            // 
            this.gMapControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl3.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.gMapControl3.Bearing = 0F;
            this.gMapControl3.CanDragMap = true;
            this.gMapControl3.CausesValidation = false;
            this.gMapControl3.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl3.GrayScaleMode = false;
            this.gMapControl3.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl3.LevelsKeepInMemmory = 5;
            this.gMapControl3.Location = new System.Drawing.Point(-1, -1);
            this.gMapControl3.MarkersEnabled = true;
            this.gMapControl3.MaxZoom = 2;
            this.gMapControl3.MinZoom = 2;
            this.gMapControl3.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl3.Name = "gMapControl3";
            this.gMapControl3.NegativeMode = false;
            this.gMapControl3.PolygonsEnabled = true;
            this.gMapControl3.RetryLoadTile = 0;
            this.gMapControl3.RoutesEnabled = true;
            this.gMapControl3.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl3.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl3.ShowTileGridLines = false;
            this.gMapControl3.Size = new System.Drawing.Size(650, 379);
            this.gMapControl3.TabIndex = 5;
            this.gMapControl3.Zoom = 0D;
            // 
            // Mapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 379);
            this.Controls.Add(this.gMapControl3);
            this.Name = "Mapa";
            this.Text = "Mapa";
            this.Load += new System.EventHandler(this.Mapa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl3;
    }
}