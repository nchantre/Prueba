using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIusuario.ServicioUsuario;

namespace UIusuario.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ServicioUsuario.UsuariosClient proxy = new ServicioUsuario.UsuariosClient();
           
            return View(proxy.GetAllUsuario());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
              UsuariosClient proxy = new UsuariosClient();
                UsuarioModels companyModels = new UsuarioModels()
                {
                    Nombre = id
                };

            return View(proxy.GetAllUsuarioNombre(companyModels.Nombre));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioModels us)
        {
            try
            {
                UsuariosClient proxy = new UsuariosClient();
                UsuarioModels companyModels = new UsuarioModels()
                {
                    Nombre = us.Nombre,
                    FechaNacimiento = Convert.ToDateTime(us.FechaNacimiento),
                    Sexo = Convert.ToChar(us.Sexo),
                };
                proxy.AddUsuario(companyModels);
                // TODO: Add insert logic here
               
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            UsuariosClient proxy = new UsuariosClient();
            UsuarioModels companyModels = new UsuarioModels()
            {
                Nombre = id
              
            };
            return View(proxy.GetAllUsuarioNombre(companyModels.Nombre));
           // return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UsuarioModels us)
        {
            try
            {

                UsuariosClient proxy = new UsuariosClient();
                UsuarioModels companyModels = new UsuarioModels()
                {
                    Nombre = id,
                    FechaNacimiento = Convert.ToDateTime(us.FechaNacimiento),
                    Sexo = Convert.ToChar(us.Sexo),
                };
                proxy.UpUsuario(companyModels);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            UsuariosClient proxy = new UsuariosClient();
            UsuarioModels companyModels = new UsuarioModels()
            {
                Nombre = id

            };
            return View(proxy.GetAllUsuarioNombre(companyModels.Nombre));       
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, UsuarioModels us)
        {
            try
            {
                UsuariosClient proxy = new UsuariosClient();
                UsuarioModels companyModels = new UsuarioModels()
                {
                    Nombre = id
                };
                
                proxy.DeleteUsuario(companyModels);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
