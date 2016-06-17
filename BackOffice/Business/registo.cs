using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BackOffice.Business
{
    public class registo
    {
        public const int ROCHA = 0;
        public const int MINERAL = 1;
        public const int ND = -1;

        public List<Bitmap> fotos { get; set; }
        // voz
        // xml

        public int tipo { get; set; } // rocha ou mineral
        public rocha rocha { get; set; }
        public mineral mineral { get; set; }

		public registo(){
			this.fotos = new List<Bitmap>();

            this.tipo = ND;
		}
		
		public registo(List<Bitmap> fotos){
			this.fotos = fotos;

            this.tipo = ND;
        }

        public registo(rocha rocha, List<Bitmap> fotos)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.rocha = rocha;
        }

        public registo(mineral mineral, List<Bitmap> fotos)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.mineral = mineral;
        }

        public void setRocha(rocha rocha)
        {
            this.rocha = rocha;
            this.tipo = ROCHA;
        }

        public void setMineral(mineral mineral)
        {
            this.mineral = mineral;
            this.tipo = MINERAL;
        }

        /*
         *  INCOMPLETO - Falta tratar da gravacao de voz,
         *  do tipo da descoberta, caracteristicas, ...
         */
        public static registo readXML(XmlNode nodo_registo)
        {
            XmlNode nodo_fotografias = nodo_registo.SelectSingleNode("fotografias");
            List<Bitmap> fotos = new List<Bitmap>();
            if(nodo_fotografias != null)
            {
                XmlNode nodo_fotografia = nodo_fotografias.SelectSingleNode("fotografia");
                for(; nodo_fotografia != null; nodo_fotografia = nodo_fotografia.NextSibling)
                {
                    string foto_str = nodo_fotografia.Value;
                    byte[] foto_bytes = Convert.FromBase64String(foto_str);
                    Bitmap foto_bmp;
                    using (var ms = new MemoryStream(foto_bytes))
                    {
                        foto_bmp = new Bitmap(ms);
                    }
                    fotos.Add(foto_bmp);
                }
            }

            XmlNode nodo_voz = nodo_registo.SelectSingleNode("voz");
            if(nodo_voz != null)
            {
                // TODO ...
            }

            return new registo(fotos);
        }

        public void addFoto(Bitmap foto){
			this.fotos.Add(foto);
		}

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
