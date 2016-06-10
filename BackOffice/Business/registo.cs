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
        private List<Bitmap> fotos { get; set; }
        // voz
        // xml

        private rocha rocha { get; set; }
        private mineral mineral { get; set; }

		public registo(){
			this.fotos = new List<Bitmap>();
		}
		
		public registo(List<Bitmap> fotos){
			this.fotos = fotos;
		}
		
		public void addFoto(Bitmap foto){
			this.fotos.Add(foto);
		}
    }
}
