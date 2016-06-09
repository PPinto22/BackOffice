using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class atividade
    {
        private Location coordenadas { get; set; }
        private List<string> objetivos { get; set; }
        private string notas { get; set; }
        private List<string> websites { get; set; }

        public atividade()
        {
            this.coordenadas = null;
            this.objetivos = new List<string>();
            this.notas = null;
            this.websites = new List<string>();
        }

        public atividade(Location coordenadas, List<string> objetivos, string notas, List<string> websites)
        {
            this.coordenadas = coordenadas;
            this.objetivos = objetivos;
            this.notas = notas;
            this.websites = websites;
        }
    }
}
