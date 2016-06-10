using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class backoffice
    {
        private Dictionary<string, utilizador> utilizadores;
        private Dictionary<int, percurso> percursos;

        public backoffice()
        {
            this.utilizadores = new Dictionary<string, utilizador>();
            this.percursos = new Dictionary<int, percurso>();
        }
		
		public HashSet<Location> getCoordenadas(){
			HashSet<Location> ret = new HashSet<Location>();
			foreach(percurso p in percursos) {
			   HashSet<Location> coordPercurso = p.getCoordenadas();
			   foreach(Location l in coordPercurso){
				   ret.Add(l);				   
			   }
			}
			
			return ret;
		}
    }
}
