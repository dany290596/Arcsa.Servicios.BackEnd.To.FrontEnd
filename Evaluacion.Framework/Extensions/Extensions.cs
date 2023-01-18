using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evaluacion.Framework.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Opcion de menu izquierda para identificar si está seleccionado y aplicar el estilo
        /// </summary>
        /// <param name="html"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (!String.IsNullOrEmpty(controller))
            {
                controller = controller.Split(',').Where(w => w == currentController).FirstOrDefault();
            }

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }
    }
}