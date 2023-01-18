using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Web.Controllers
{
    public class InteresesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
