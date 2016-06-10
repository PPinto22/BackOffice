using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace BackOffice.Business
{
    class backoffice
    {
        public Dictionary<string, utilizador> utilizadores;
        public Dictionary<int, percurso> percursos;

        public backoffice()
        {
            this.utilizadores = new Dictionary<string, utilizador>();
            this.percursos = new Dictionary<int, percurso>();
        }
		
		public HashSet<PointLatLng> getCoordenadas(){
			HashSet<PointLatLng> ret = new HashSet<PointLatLng>();
			foreach(percurso p in percursos.Values) {
			   HashSet<PointLatLng> coordPercurso = p.getCoordenadas();
			   foreach(PointLatLng l in coordPercurso){
				   ret.Add(l);				   
			   }
			}
			
			return ret;
		}
    }
}
