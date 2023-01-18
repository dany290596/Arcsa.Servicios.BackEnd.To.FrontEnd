using Evaluacion.Data.Context;
using Evaluacion.Data.Implements.Common;
using Evaluacion.Data.Interfaces.Cv;
using Evaluacion.Domain.Entities.Cv;
using System.Linq.Expressions;

namespace Evaluacion.Data.Implements.Cv
{
    public class InformacionRepository : Repository<Informacion>, IInformacionRepository
    {
        public InformacionRepository(EvaluacionContext context) : base(context) { }

        public Informacion GetFirstOrDefaultInformation(Expression<Func<Informacion, bool>> predicate)
        {
            return _context.Informacion.
                FirstOrDefault(predicate);
        }
    }
}