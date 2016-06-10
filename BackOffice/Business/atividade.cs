using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace BackOffice.Business
{
    class atividade
    {
        public PointLatLng coordenadas { get; set; }
        public List<string> objetivos { get; set; }
        public string notas { get; set; }
        public List<string> websites { get; set; }

        public registo registo { get; set; }

        public atividade()
        {
            this.coordenadas = new PointLatLng();
            this.objetivos = new List<string>();
            this.notas = null;
            this.websites = new List<string>();
            this.registo = null;
        }

        public atividade(PointLatLng coordenadas, List<string> objetivos, string notas, List<string> websites)
        {
            this.coordenadas = coordenadas;
            this.objetivos = objetivos;
            this.notas = notas;
            this.websites = websites;
            this.registo = null;
        }

        public atividade(PointLatLng coordenadas, List<string> objetivos, string notas, List<string> websites, registo registo)
        {
            this.coordenadas = coordenadas;
            this.objetivos = objetivos;
            this.notas = notas;
            this.websites = websites;
            this.registo = registo;
        }

        public static atividade readXML()
        {
            // TODO
            return new atividade();
        }

        public string writeXML()
        {
            StringBuilder sb = new StringBuilder();

            // TODO

            return sb.ToString();
        }

        public void addObjetivo(string objetivo)
        {
            this.objetivos.Add(objetivo);
        }

        public void addWebsite(string html)
        {
            this.websites.Add(html);
        }
    }
}
