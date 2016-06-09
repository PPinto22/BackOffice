using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Business
{
    class utilizador
    {
        private string email { get; set; }
        private string password { get; set; }
        private string nome { get; set; }

        public utilizador(string email, string password, string nome)
        {
            this.email = email;
            this.password = password;
            this.nome = nome;
        }
    }
}
