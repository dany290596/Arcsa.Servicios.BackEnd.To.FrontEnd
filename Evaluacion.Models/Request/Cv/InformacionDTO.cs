using Evaluacion.Models.Request.Common;

namespace Evaluacion.Models.Request.Cv
{
    public class InformacionDTO : BaseEntityDTO
    {
        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Sexo { get; set; }

        public string PaisResidencia { get; set; }
    }
}
