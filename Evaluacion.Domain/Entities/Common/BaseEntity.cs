namespace Evaluacion.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public byte? Estado { get; set; }
    }
}