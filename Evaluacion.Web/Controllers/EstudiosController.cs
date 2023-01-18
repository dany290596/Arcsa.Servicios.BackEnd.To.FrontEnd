using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Web.Controllers
{
    public class EstudiosController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
