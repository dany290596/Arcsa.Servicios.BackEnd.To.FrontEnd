using Evaluacion.Data.Context;
using Evaluacion.Data.Implements.Cv;
using Evaluacion.Data.Interfaces.Common;
using Evaluacion.Data.Interfaces.Cv;

namespace Evaluacion.Data.Implements.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EvaluacionContext _context;
        private readonly IInformacionRepository _informacionRepository;

        public UnitOfWork(
            EvaluacionContext context
            )
        {
            _context = context;
        }

        public IInformacionRepository InformacionRepository => _informacionRepository ?? new InformacionRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }       
    }
}