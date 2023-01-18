using Evaluacion.Domain.Entities.Cv;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion.Data.Context
{
    public class EvaluacionContext : DbContext
    {
        public EvaluacionContext()
        {
        }

        public EvaluacionContext(DbContextOptions<EvaluacionContext> options) : base(options)
        {
        }

        public virtual DbSet<Informacion> Informacion { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}