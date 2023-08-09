using GRUD_Asp.Net.Datos;
using GRUD_Asp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace GRUD_Asp.Net.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            //Aplicamos la inyeccion de dependencia y por medio de la variable contexto, podemos acceder a cualquier propieda o modelo que
            //contenga el programa
            _contexto = contexto;
        }
        //----------------------------------------------------------------------------------------------------------------
        //Le indicamos que vamos a obtener datos de la base con ese metodo
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Utilizamos Entity frameWord para acceder a nuestra entidad
            return View(await _contexto.Contacts.ToListAsync());
        }

        //----------------------------------------------------------------------------------------------------------------
        //Metodo para mostrar la vista de agregar un nuevo usuario
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            return View();
        }
        //metodo para guardar los datos de la vista de agregar.
        [HttpPost]
        [ValidateAntiForgeryToken]//Validamos algun ataque de virus de tipo xss
        public async Task<IActionResult> Crear(Contact contanto)
        {
            //Validamos que las validacione del modelo esten correctos
            if (ModelState.IsValid)
            {
                contanto.FechaCreacion = DateTime.Now;
                _contexto.Contacts.Add(contanto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));//Para que me direccione al index de este controlador
            }
            return View();
        }

        //----------------------------------------------------------------------------------------------------------------
        //Metodo para la vista de editar
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            //Evaluamos que hay un id como parametro
            if (id == null)
            {
                return NotFound();

            }
            //Evaluamos si lo encontro o no
            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        //Metodo para la Guardar los cambios de la vista de  editar
        [HttpPost]
        [ActionName("Editar")]
        [ValidateAntiForgeryToken]//Validamos algun ataque de virus de tipo xss
        public async Task<IActionResult> Editar(Contact contacto, int id)
        {
            //Validamos que las validacione del modelo esten correctos
            if (ModelState.IsValid)
            {
                if (id == contacto.Id)
                {
                    contacto.FechaCreacion = DateTime.Now;
                    _contexto.Update(contacto);
                    await _contexto.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));//Para que me direccione al index de este controlador
                }

            }
            return View(contacto);
        }

        //----------------------------------------------------------------------------------------------------------------
        //Metodo para la vista de detalle
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            //Evaluamos que hay un id como parametro
            if (id == null)
            {
                return NotFound();

            }
            //Evaluamos si lo encontro o no y retornamos
            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }



        //----------------------------------------------------------------------------------------------------------------
        //Metodo para la vista de eliminar
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            //Evaluamos que hay un id como parametro
            if (id == null)
            {
                return NotFound();

            }
            //Evaluamos si lo encontro o no
            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        //Metodo para la Guardar los cambios de la vista de  editar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]//Validamos algun ataque de virus de tipo xss

        public async Task<IActionResult> EliminarContacto(int id)
        {
            var contacto = await _contexto.Contacts.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            //Borramos el contacto
            _contexto.Contacts.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult _EditContact(int id)
        {
            var contacto = _contexto.Contacts.Find(id);
            return PartialView("_EditContact", contacto);
        }
        [HttpGet]
        public IActionResult _DeleteContact(int id)
        {
            var Contacto = _contexto.Contacts.Find(id);
            return PartialView("_DeleteContact", Contacto);
        }
        [HttpGet]
        public IActionResult _DetailsContact(int id)
        {

            var contacto = _contexto.Contacts.Find(id);

            return PartialView("_DetailsContact", contacto);

        }

        [HttpGet]
        public IActionResult _SaludarContacto(int? id)
        {
            var contacto = _contexto.Contacts.Find(id);
            return PartialView("_SaludarContacto", contacto);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



       