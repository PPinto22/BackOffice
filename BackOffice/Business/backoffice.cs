using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using BackOffice.DAO;

namespace BackOffice.Business
{
    public class backoffice
    {
        public utilizadoresDAO utilizadores;
        public percursosDAO percursos;

        public backoffice()
        {
            this.utilizadores = new utilizadoresDAO();
            this.percursos = new percursosDAO();
        }
		
        public HashSet<PointLatLng> getCoodenadas()
        {
            return this.percursos.getCoordenadas();
        }

    }
}
