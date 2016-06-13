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
    public class atividade
    {
        public PointLatLng coordenadas { get; set; }
        public string objetivos { get; set; }
        public string notas { get; set; }
        public List<string> websites { get; set; }

        public registo registo { get; set; }

        public atividade()
        {
            this.coordenadas = new PointLatLng();
            this.objetivos = string.Empty;
            this.notas = string.Empty;
            this.websites = new List<string>();
            this.registo = null;
        }

        public atividade(PointLatLng coordenadas, string objetivos, string notas, List<string> websites)
        {
            this.coordenadas = coordenadas;
            this.objetivos = objetivos;
            this.notas = notas;
            this.websites = websites;
            this.registo = null;
        }

        public atividade(PointLatLng coordenadas, string objetivos, string notas, List<string> websites, registo registo)
        {
            this.coordenadas = coordenadas;
            this.objetivos = objetivos;
            this.notas = notas;
            this.websites = websites;
            this.registo = registo;
        }

        public static atividade readXML(XmlNode nodo_atividade)
        {
            XmlNode localizacao = nodo_atividade.SelectSingleNode("localizacao");
            if (localizacao == null) throw new XmlException("Localizacao de atividade invalida");

            double longitude, latitude;
            var attr = localizacao.Attributes["longitude"];
            if (attr != null) longitude = double.Parse(attr.Value);
            else throw new XmlException("Localizacao de atividade invalida");

            attr = localizacao.Attributes["latitude"];
            if (attr != null) latitude = double.Parse(attr.Value);
            else throw new XmlException("Localizacao de atividade invalida");

            string objetivos = string.Empty;
            XmlNode nodo_objetivos = nodo_atividade.SelectSingleNode("objetivos");
            if (nodo_objetivos != null)
            {
                objetivos = nodo_objetivos.Value;
            }

            XmlNode nodo_registo = nodo_atividade.SelectSingleNode("registo");
            if (nodo_registo == null) throw new XmlException("Atividade sem registos");

            registo registo = registo.readXML(nodo_registo);

            return new atividade(new PointLatLng(latitude,longitude),objetivos,string.Empty,null,registo);
        }

        public void writeXML(XmlWriter writer)
        {
            writer.WriteStartElement("atividade");

            //localizacao
            writer.WriteStartElement("localizacao");
            writer.WriteStartAttribute("longitude");
            writer.WriteString(coordenadas.Lng.ToString());
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("latitude");
            writer.WriteString(coordenadas.Lat.ToString());
            writer.WriteEndAttribute();
            writer.WriteEndElement();

            //Objetivos
            writer.WriteStartElement("objetivos");
            writer.WriteString(this.objetivos);
            writer.WriteEndElement();

            //Informacao
            writer.WriteStartElement("informacao");
            //Notas
            writer.WriteStartElement("notas");
            writer.WriteString(this.notas);
            writer.WriteEndElement();
            //Links
            foreach(string html in this.websites)
            {
                writer.WriteStartElement("link");
                writer.WriteString(html);
                writer.WriteEndElement();
            }

            writer.WriteEndElement(); // </informacao>
            writer.WriteEndElement(); // </atividade>
        }

        public void addWebsite(string html)
        {
            this.websites.Add(html);
        }
    }
}
