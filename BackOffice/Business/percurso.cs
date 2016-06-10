using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace BackOffice.Business
{
    class percurso
    {
        public DateTime data { get; set; }
        public List<atividade> atividades { get; set; }
        public string utilizador;

        public percurso(DateTime data, List<atividade> atividades, string utilizador)
        {
            this.data = data;
            this.atividades = atividades;
            this.utilizador = utilizador;
        }

		public HashSet<PointLatLng> getCoordenadas(){
			HashSet<PointLatLng> ret = new HashSet<PointLatLng>();
			foreach(atividade a in atividades) {
                PointLatLng l = a.coordenadas;
			   ret.Add(l);
			}
			
			return ret;
		}
		
        public void addAtividade(atividade atv)
        {
            this.atividades.Add(atv);
        }
    }
}
