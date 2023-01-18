using Evaluacion.Data.Interfaces.Common;
using Evaluacion.Domain.Entities.Cv;
using Evaluacion.Services.Interfaces.Cv;

namespace Evaluacion.Services.Services.Cv
{
    public class InformacionService : IInformacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InformacionService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Informacion informacion)
        {
            bool booOk = false;

            try
            {
                informacion.Id = Guid.NewGuid();
                informacion.FechaCreacion = DateTime.Now;
                informacion.Estado = 1;

                await _unitOfWork.InformacionRepository.Add(informacion);

                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                booOk = false;
            }

            return booOk;
        }

        public async Task<bool> Activate(Guid id)
        {
            bool booOk = false;

            try
            {
                Informacion informacion = await _unitOfWork.InformacionRepository.GetById(id);
                informacion.Estado = 1;

                _unitOfWork.InformacionRepository.Update(informacion);
                await _unitOfWork.SaveChangesAsync();

                booOk = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return booOk;
        }

        public async Task<bool> Inactivate(Guid id)
        {
            bool booOk = false;

            try
            {
                Informacion informacion = await _unitOfWork.InformacionRepository.GetById(id);

                if (informacion != null)
                {
                    informacion.Estado = 2;

                    _unitOfWork.InformacionRepository.Update(informacion);
                    await _unitOfWork.SaveChangesAsync();

                    booOk = true;
                }
                else
                {
                    booOk = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return booOk;
        }

        public Informacion GetByInformationId(Guid informacionId)
        {
            Informacion informacion = _unitOfWork.InformacionRepository.GetFirstOrDefaultInformation(g => g.Id == informacionId);

            return informacion;
        }

        public IEnumerable<Informacion> GetAll()
        {
            var informacion = _unitOfWork.InformacionRepository.GetAll();

            return informacion;
        }

        public async Task<bool> Update(Informacion informacion)
        {
            try
            {
                Informacion currentInformation = await _unitOfWork.InformacionRepository.GetById(informacion.Id);

                currentInformation.Nombre = informacion.Nombre;
                currentInformation.Correo = informacion.Correo;
                currentInformation.Telefono = informacion.Telefono;
                currentInformation.Sexo = informacion.Sexo;
                currentInformation.PaisResidencia = informacion.PaisResidencia;

                _unitOfWork.InformacionRepository.Update(currentInformation);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}