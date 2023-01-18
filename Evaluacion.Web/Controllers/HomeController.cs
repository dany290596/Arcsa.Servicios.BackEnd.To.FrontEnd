using Evaluacion.Models.Response.Menu;
using Evaluacion.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluacion.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {

            MenuProfileDTO menuProfileDTO = new MenuProfileDTO
            {
                modulos = new Modulos[]
                {
                        new Modulos
                        {
                            id = "98a61675-93c3-45cb-a087-f03f19ac8920",
                            nombre = "Estudios",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "173fca98-ca2d-4aa4-8788-e5e806dc55fd",
                                    nombre = "Estudios",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        },
                        new Modulos
                        {
                            id = "02539820-eacc-4473-abe1-9e9f57663a6d",
                            nombre = "Experiencia Laboral",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "2e1c4942-e4e1-427a-b3b0-66e427be6a79",
                                    nombre = "Experiencia Laboral",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        },
                        new Modulos
                        {
                            id = "acd850c0-e034-4c0f-8c55-786d3043913f",
                            nombre = "Conocimientos",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "0a27e90a-34bb-44cf-8189-d5a00514e8ae",
                                    nombre = "Conocimientos",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        },
                        new Modulos
                        {
                            id = "6e45031e-5700-464a-9080-a55ce1e4a0d8",
                            nombre = "Idiomas",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "b52b8403-1305-4ad0-bb89-7927b560183f",
                                    nombre = "Idiomas",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        },
                        new Modulos
                        {
                            id = "3b8fab79-3695-4b70-8aa2-b9c5bebd5df3",
                            nombre = "Intereses",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "8989fa42-a766-4ef4-b3a7-b7e84ea076ba",
                                    nombre = "Intereses",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        },
                        new Modulos
                        {
                            id = "9d2e1423-c79b-4e95-ac43-9d571dbabf7c",
                            nombre = "Datos Personales",
                            imagen = "",
                            orden = 1,
                            secciones = new Secciones[]
                            {
                                new Secciones
                                {
                                    id = "80a707e6-40c7-4673-b31e-11da64c1d2d4",
                                    nombre = "Datos Personales",
                                    imagen = "",
                                    orden = 1
                                }
                            }
                        }
                }
            };

            HttpContext.Session.SetString(CommonSession.CURRENT_MENU, JsonConvert.SerializeObject(menuProfileDTO));
            ViewBag.Menu = HttpContext.Session.GetString(CommonSession.CURRENT_MENU);

            return RedirectToAction("Index", "Informacion");
        }
    }
}