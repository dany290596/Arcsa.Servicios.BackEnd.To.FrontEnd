using AutoMapper;
using Evaluacion.Domain.Entities.Cv;

namespace Evaluacion.Infrastructure.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                CreateMap<Informacion, Models.Response.Cv.InformacionDTO>().ReverseMap();

                CreateMap<Informacion, Models.Request.Cv.InformacionDTO>().ReverseMap();
            });
        }
    }
}