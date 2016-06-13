using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using BackOffice.DAO;

namespace BackOffice.Business
{
    public class backoffice
    {
        public utilizadoresDAO utilizadores;
        public Dictionary<int, percurso> percursos;

        public backoffice()
        {
            this.utilizadores = new utilizadoresDAO();
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
