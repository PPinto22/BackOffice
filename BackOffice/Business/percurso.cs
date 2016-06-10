using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using System.Xml;
using System.IO;

namespace BackOffice.Business
{
    class percurso
    {
        public DateTime data { get; set; }
        public List<atividade> atividades { get; set; }
        public string utilizador { get; set; }

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

        public static percurso readXML(XmlNode sessao)
        {
            XmlNode data = sessao.SelectSingleNode("/data");
           
            // TODO

            return null;
        }

        public string writeXML()
        {
            StringBuilder sb = new StringBuilder();

            // TODO ...

            return sb.ToString();

        }
		
        public void addAtividade(atividade atv)
        {
            this.atividades.Add(atv);
        }
    }
}
