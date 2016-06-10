using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    public class rocha
    {
        public string designacao { get; set; }
        public string tipo { get; set; }
        public float peso { get; set; }
        public string textura { get; set; }
        public string cor { get; set; }

        public rocha() { }
        public rocha(string designacao, string tipo, float peso, string textura, string cor)
        {
            this.designacao = designacao;
            this.tipo = tipo;
            this.peso = peso;
            this.textura = textura;
            this.cor = cor;
        }
    }
}
