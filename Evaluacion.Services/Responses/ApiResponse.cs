using Evaluacion.Domain.EntitiesCustom;

namespace Evaluacion.Services.Responses
{
    public class ApiResponse<T>
    {
        public bool Respuesta { get; set; }

        public string Mensaje { get; set; }

        public int Codigo { get; set; }

        public T Data { get; set; }

        public ApiResponse(bool respuesta, string mensaje, int codigo, T data)
        {
            Respuesta = respuesta;
            Mensaje = mensaje;
            Codigo = codigo;
            Data = data;
        }
    }
}