using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class mineral
    {
        private string designacao { get; set; }
        private float peso { get; set; }
        private string risca { get; set; }
        private string cor { get; set; }

        public mineral() { }
        public mineral(string designacao, float peso, string risca, string cor)
        {
            this.designacao = designacao;
            this.peso = peso;
            this.risca = risca;
            this.cor = cor;
        }
    }
}
