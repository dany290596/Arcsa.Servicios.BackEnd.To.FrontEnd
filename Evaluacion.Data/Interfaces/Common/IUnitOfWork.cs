using Evaluacion.Data.Interfaces.Cv;

namespace Evaluacion.Data.Interfaces.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IInformacionRepository InformacionRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();       
    }
}