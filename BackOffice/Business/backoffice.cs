using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class backoffice
    {
        private Dictionary<string, utilizador> utilizadores;
        private Dictionary<int, percurso> percursos;

        public backoffice()
        {
            this.utilizadores = new Dictionary<string, utilizador>();
            this.percursos = new Dictionary<int, percurso>();
        }
    }
}
