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
        public byte[] voz { get; set; }
        public string traducao { get; set; }

        public int tipo { get; set; } // rocha ou mineral
        public rocha rocha { get; set; }
        public mineral mineral { get; set; }

		public registo(){
			this.fotos = new List<Bitmap>();
            this.traducao = String.Empty;
            this.tipo = ND;
		}       
		
		public registo(List<Bitmap> fotos, byte[] voz, string traducao){
			this.fotos = fotos;
            this.traducao = String.Empty;
            this.tipo = ND;
            this.voz = voz;
            this.traducao = traducao;
        }

        public registo(rocha rocha, List<Bitmap> fotos, byte[] voz)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.rocha = rocha;
            this.voz = voz;
            this.traducao = String.Empty;
        }

        public registo(mineral mineral, List<Bitmap> fotos, byte[] voz)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.mineral = mineral;
            this.voz = voz;
            this.traducao = String.Empty;
        }

        public void setRocha(rocha rocha)
        {
            this.rocha = rocha;
            this.tipo = ROCHA;
        }
        public registo(rocha rocha, List<Bitmap> fotos, byte[] voz, string traducao)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.rocha = rocha;
            this.voz = voz;
            this.traducao = traducao;
        }
        public registo(mineral mineral, List<Bitmap> fotos, byte[] voz, string traducao)
        {
            this.tipo = ROCHA;
            this.fotos = fotos;
            this.mineral = mineral;
            this.voz = voz;
            this.traducao = traducao;
        }

        public void setMineral(mineral mineral)
        {
            this.mineral = mineral;
            this.tipo = MINERAL;
        }
        
        public static registo readXML(XmlNode nodo_registo)
        {
            XmlNode nodo_fotografias = nodo_registo.SelectSingleNode("fotografias");
            List<Bitmap> fotos = new List<Bitmap>();
            if(nodo_fotografias != null)
            {
                XmlNode nodo_fotografia = nodo_fotografias.SelectSingleNode("fotografia");
                for(; nodo_fotografia != null; nodo_fotografia = nodo_fotografia.NextSibling)
                {
                    string foto_str = nodo_fotografia.InnerText;
                    if (!String.IsNullOrEmpty(foto_str))
                    {
                        byte[] foto_bytes = Convert.FromBase64String(foto_str);
                        Bitmap foto_bmp;
                        foto_bmp = (Bitmap)registo.byteArrayToImage(foto_bytes);
                        fotos.Add(foto_bmp);
                    }
                }
            }

            XmlNode nodo_voz = nodo_registo.SelectSingleNode("voz");
            byte[] voz = null;
            if(nodo_voz != null)
            {
                string v = nodo_voz.InnerText;
                if (!String.IsNullOrEmpty(v)) {
                    voz = Convert.FromBase64String(v);
                }
            }
            XmlNode nodo_rocha = nodo_registo.SelectSingleNode("rocha");
            XmlNode nodo_mineral = nodo_registo.SelectSingleNode("mineral");

            // TODO pegar na voz e traduzir
            registo reg = new registo(fotos,voz,String.Empty);
            if (nodo_rocha != null)
            {
                reg.setRocha(rocha.readXml(nodo_rocha));
            }
            if (nodo_mineral != null)
            {
                reg.setMineral(mineral.readXml(nodo_mineral));
            }
            return reg;
        }

        public void addFoto(Bitmap foto){
			this.fotos.Add(foto);
		}

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                
                imageIn.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
