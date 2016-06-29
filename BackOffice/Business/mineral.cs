using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BackOffice.Business
{
    public class mineral
    {
        public string designacao { get; set; }
        public float peso { get; set; }
        public string risca { get; set; }
        public string cor { get; set; }

        public mineral() {
            this.designacao = string.Empty;
            this.peso = 0;
            this.risca = string.Empty;
            this.cor = string.Empty;
        }
        public mineral(string designacao, float peso, string risca, string cor)
        {
            this.designacao = designacao;
            this.peso = peso;
            this.risca = risca;
            this.cor = cor;
        }
        public static mineral readXml(XmlNode x)
        {
            XmlNode designacao = x.SelectSingleNode("designacao");
            string d = designacao.InnerText;
            XmlNode peso = x.SelectSingleNode("peso");
            if (peso == null) throw new XmlException();
            float p = float.Parse(peso.InnerText, CultureInfo.InvariantCulture);
            XmlNode risca = x.SelectSingleNode("risca");
            if (risca == null) throw new XmlException();
            string r = risca.InnerText;
            XmlNode cor = x.SelectSingleNode("cor");
            if (cor == null) throw new XmlException();
            string c = cor.InnerText;
            mineral mineral = new mineral(d, p, r, c);
            return mineral;
        }
    }
}
