using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Web.Controllers
{
    public class IdiomasController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
