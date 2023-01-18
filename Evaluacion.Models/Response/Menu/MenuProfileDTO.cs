using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Models.Response.Menu
{
    public class MenuProfileDTO
    {
        public Modulos[] modulos { get; set; }
    }

    public class Modulos
    {
        public string id { get; set; }

        public string nombre { get; set; }

        public string imagen { get; set; }

        public int orden { get; set; }

        public Secciones[] secciones { get; set; }
    }

    public class Secciones
    {
        public string id { get; set; }

        public string nombre { get; set; }

        public string imagen { get; set; }

        public int orden { get; set; }
    }
}