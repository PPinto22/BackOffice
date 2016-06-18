﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using System.Xml;
using System.IO;

namespace BackOffice.Business
{
    public class percurso
    {
        public DateTime data { get; set; }
        public List<atividade> atividades { get; set; }
        public string utilizador { get; set; }

        public atividadesDAO atividadesDAO { get; set; }

        public percurso()
        {
            this.data = new DateTime();
            this.atividades = new List<atividade>();
            this.utilizador = string.Empty;

            this.atividadesDAO = null;
        }

        public percurso(DateTime data, string utilizador, int idPercursoBD)
        {
            this.data = data;
            this.atividades = new List<atividade>();
            this.utilizador = utilizador;
            this.atividadesDAO = new atividadesDAO(idPercursoBD);
        }

        public percurso(DateTime data, string utilizador)
        {
            this.data = data;
            this.atividades = new List<atividade>();
            this.utilizador = utilizador;

            this.atividadesDAO = null;
        }

        public percurso(DateTime data, List<atividade> atividades, string utilizador)
        {
            this.data = data;
            this.atividades = atividades;
            this.utilizador = utilizador;

            this.atividadesDAO = null;
        }

        public void loadAtividades()
        {
            if (this.atividadesDAO == null) return;
            this.atividades = this.atividadesDAO.getAtividades();
        }

		public HashSet<PointLatLng> getCoordenadas(){
			HashSet<PointLatLng> ret = new HashSet<PointLatLng>();
			foreach(atividade a in atividades) {
                PointLatLng l = a.coordenadas;
			    ret.Add(l);
			}
			
			return ret;
		}

        public static percurso readXML(XmlDocument xmlDoc, string utilizador)
        {
            XmlNode sessao = xmlDoc.SelectSingleNode("sessao");
            if (sessao == null) throw new XmlException();

            XmlNode nodo_data = sessao.SelectSingleNode("data");
            int ano, mes, dia, hora, minuto;
            if (nodo_data == null || nodo_data.Attributes == null) throw new XmlException("Data invalida");
            var attr = nodo_data.Attributes["ano"];
            if (attr != null) ano = int.Parse(attr.InnerText);
            else throw new XmlException("Data invalida");

            attr = nodo_data.Attributes["mes"];
            if (attr != null) mes = int.Parse(attr.InnerText);
            else throw new XmlException("Data invalida");

            attr = nodo_data.Attributes["dia"];
            if (attr != null) dia = int.Parse(attr.InnerText);
            else throw new XmlException("Data invalida");

            attr = nodo_data.Attributes["hora"];
            if (attr != null) hora = int.Parse(attr.InnerText);
            else throw new XmlException("Data invalida");

            attr = nodo_data.Attributes["minuto"];
            if (attr != null) minuto = int.Parse(attr.InnerText);
            else throw new XmlException("Data invalida");

            DateTime dt = new DateTime(ano, mes, dia, hora, minuto, 0);
            percurso novo_percurso = new percurso(dt, utilizador);

            XmlNode nodo_atividade = sessao.SelectSingleNode("atividade");
            if (nodo_atividade == null) throw new XmlException("Sem atividades");

            for (; nodo_atividade != null; nodo_atividade = nodo_atividade.NextSibling)
            {
                if (nodo_atividade.NodeType == XmlNodeType.Element)
                {
                    atividade atv = atividade.readXML(nodo_atividade);
                    novo_percurso.addAtividade(atv);
                }
            }

            return novo_percurso;
        }

        public string writeXML()
        {
            StringWriterWithEncoding sw = new StringWriterWithEncoding(Encoding.UTF8);

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(sw, ws))
            {
                writer.WriteStartElement("sessao");
                foreach(atividade a in this.atividades)
                {
                    a.writeXML(writer);
                }
                writer.WriteEndElement();
            }

            return sw.ToString();

        }
		
        public void addAtividade(atividade atv)
        {
            this.atividades.Add(atv);
        }
    }
}
