using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class percurso
    {
        private DateTime data { get; set; }
        private List<atividade> atividades { get; set; }
        private string utilizador;

        public percurso(DateTime data, List<atividade> atividades, string utilizador)
        {
            this.data = data;
            this.atividades = atividades;
            this.utilizador = utilizador;
        }

		public HashSet<Location> getCoordenadas(){
			HashSet<Location> ret = new HashSet<Location>();
			foreach(atividade a in atividades) {
			   Location l = a.getCoordenadas();
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
