using Evaluacion.Domain.Entities.Cv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Services.Interfaces.Cv
{
    public interface IInformacionService
    {
        Task<bool> Create(Informacion informacion);

        Task<bool> Activate(Guid id);

        Task<bool> Inactivate(Guid id);

        Task<bool> Update(Informacion informacion);

        Informacion GetByInformationId(Guid informacionId);

        IEnumerable<Informacion> GetAll();
    }
}