using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BackOffice.Business
{
    public class rocha
    {
        public string designacao { get; set; }
        public string tipo { get; set; }
        public float peso { get; set; }
        public string textura { get; set; }
        public string cor { get; set; }

        public rocha() {
            this.designacao = string.Empty;
            this.tipo = string.Empty;
            this.peso = 0;
            this.textura = string.Empty;
            this.cor = string.Empty;
        }
        public rocha(string designacao, string tipo, float peso, string textura, string cor)
        {
            this.designacao = designacao;
            this.tipo = tipo;
            this.peso = peso;
            this.textura = textura;
            this.cor = cor;
        }
        public static rocha readXml (XmlNode x)
        {
            XmlNode designacao = x.SelectSingleNode("designacao");
            string d = designacao.InnerText;
            XmlNode tipo = x.SelectSingleNode("tipo");
            string t = tipo.InnerText;
            XmlNode peso = x.SelectSingleNode("peso");
            float p = float.Parse(peso.InnerText, CultureInfo.InvariantCulture);
            XmlNode textura = x.SelectSingleNode("textura");
            string tex = textura.InnerText;
            XmlNode cor = x.SelectSingleNode("cor");
            string c = cor.InnerText;
            rocha rocha = new rocha(d,t,p,tex,c);
            return rocha;
        }
    }
}
