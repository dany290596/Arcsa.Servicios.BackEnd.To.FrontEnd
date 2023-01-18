using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evaluacion.Web.Controllers
{
    public class BaseController : Controller
    {
        private const string TEXT = "Text";
        private const string TEXT_VALUE = "Value";

        public BaseController() { }

        protected SelectList SetNumPagesMultiple(int numPages, string currentPage)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            for (int i = 1; i <= numPages; i++)
            {
                listItems.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            return new SelectList(listItems,
                TEXT,
                TEXT_VALUE, currentPage);
        }

        protected void SetNumPages(int numPages, string currentPage)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            for (int i = 1; i <= numPages; i++)
            {
                listItems.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.NumPages = new SelectList(listItems,
                TEXT,
                TEXT_VALUE, currentPage);
        }

        protected SelectList SetPageSizeMultiple(string pageSize)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            string[] numPages = { "10", "25", "50" };

            foreach (var n in numPages)
            {
                listItems.Add(new SelectListItem { Text = n, Value = n });
            }

            return new SelectList(listItems,
                TEXT,
                TEXT_VALUE, pageSize);
        }

        protected void SetPageSize(string pageSize)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            string[] numPages = { "10", "25", "50" };

            foreach (var n in numPages)
            {
                listItems.Add(new SelectListItem { Text = n, Value = n });
            }

            ViewBag.Pager = new SelectList(listItems,
                TEXT,
                TEXT_VALUE, pageSize);
        }
    }
}