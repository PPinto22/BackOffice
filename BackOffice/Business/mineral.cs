﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class mineral
    {
        public string designacao { get; set; }
        public float peso { get; set; }
        public string risca { get; set; }
        public string cor { get; set; }

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
