using Evaluacion.Data.Interfaces.Common;
using Evaluacion.Domain.Entities.Cv;
using System.Linq.Expressions;

namespace Evaluacion.Data.Interfaces.Cv
{
    public interface IInformacionRepository : IRepository<Informacion>
    {
        Informacion GetFirstOrDefaultInformation(Expression<Func<Informacion, bool>> predicate);
    }
}