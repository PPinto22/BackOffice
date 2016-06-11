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
    class registo
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
    }
}
