using Evaluacion.Domain.Entities.Common;

namespace Evaluacion.Domain.Entities.Cv
{
	public class Informacion : BaseEntity
	{
		public string Nombre { get; set; }

		public string Correo { get; set; }

		public string Telefono { get; set; }

		public string Sexo { get; set; }

		public string PaisResidencia { get; set; }
	}
}