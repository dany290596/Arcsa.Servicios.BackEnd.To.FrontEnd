using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Web.Controllers
{
    public class DatosPersonalesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
