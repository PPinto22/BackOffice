using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class registo
    {
        public const int ROCHA = 0;
        public const int MINERAL = 1;
        public const int VAZIO = -1;

        public List<Bitmap> fotos { get; set; }
        // voz
        // xml

        public int tipo; // rocha ou mineral
        public rocha rocha { get; set; }
        public mineral mineral { get; set; }

		public registo(){
			this.fotos = new List<Bitmap>();

            this.tipo = VAZIO;
		}
		
		public registo(List<Bitmap> fotos){
			this.fotos = fotos;

            this.tipo = VAZIO;
        }

        public void addFoto(Bitmap foto){
			this.fotos.Add(foto);
		}
    }
}
