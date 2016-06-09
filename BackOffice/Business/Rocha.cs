using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    public class rocha
    {
        private string designacao { get; set; }
        private string tipo { get; set; }
        private float peso { get; set; }
        private string textura { get; set; }
        private string cor { get; set; }

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
