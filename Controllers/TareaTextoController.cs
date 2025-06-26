
using System.Web.Mvc;
using FinalASP.NET.Logic;
using FinalASP.NET.Models;

namespace FinalASP.NET.Controllers
{
    public class TareaTextoController : Controller
    {
        // GET: TareaTexto
        public ActionResult Index()
        {
            var lista = TareaL.ObtenerTodos();
            return View(lista);
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Crear(Class1 tareaTexto)
        {
            if (ModelState.IsValid)
            {
                var error = TareaL.Guardar(tareaTexto);
                if (error == null)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", error);
            }
            return View(tareaTexto);
        }



        public ActionResult Edit(int id)
        {
            var TareaTexto = TareaL.ObtenerPorId(id);
            if (TareaTexto == null)
            {
                return HttpNotFound();
            }
            return View(TareaTexto);
        }
        [HttpPost]
        public ActionResult Edit(Class1 TareaTexto)
        {
            if (ModelState.IsValid)
            {
                var error = TareaL.Actualizar(TareaTexto);
                if (error == null)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", error);
            }
            return View(TareaTexto);

        }
        public ActionResult Delete(int id)
        {
            var TareaTexto = TareaL.ObtenerPorId(id);
            if (TareaTexto == null)
            {
                return HttpNotFound();
            }
            return View(TareaTexto);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var erorr = TareaL.Eliminar(id);
            if (erorr == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");


        }
    }
}