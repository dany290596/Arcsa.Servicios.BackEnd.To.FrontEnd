using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Web.Controllers
{
    public class ConocimientosController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
