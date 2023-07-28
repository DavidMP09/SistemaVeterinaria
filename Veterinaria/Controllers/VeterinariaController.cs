using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class VeterinariaController : Controller
    {
        // GET: Veterinaria
        DaoVeterinario daoveterinaria = new DaoVeterinario();
        DaoCalendario daocalendario = new DaoCalendario();
        DaoCliente daocliente = new DaoCliente();
        DaoHistorial daohistorial = new DaoHistorial();
        DaoServicios daoservicios = new DaoServicios();
        DaoMascota daomascota = new DaoMascota();
        DaoCitas daocitas = new DaoCitas();
        DaoUsuario daoUsuario = new DaoUsuario();

        // GET: Veterinaria
        public ActionResult ListarUsuario()
        {
            List<Usuario> listado = daoUsuario.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }

            return View(listado);
        }
        public ActionResult editarUsuario(int id)
        {
            Usuario usuario = daoUsuario.buscarID(id);
            return View(usuario);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarUsuario(Usuario usuario)
        {  //modelstate esdado del modelo
            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daoUsuario.actualizarusuario(usuario);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del Usuario actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del Usuario..";
                    }
                }
                return RedirectToAction("ListarUsuario");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarUsuario");
            }
        }
        public ActionResult borrarusuario(int id)
        {
            Usuario usuario = daoUsuario.buscarID(id);
            return View(usuario);
        }
        [HttpPost]
        public ActionResult eliminarUsuario(int id)
        {

            try
            {
                string resultado = daoUsuario.borrarusuario(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarUsuario");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarusuario");
            }
        }
        public ActionResult ListarVeterinario()
        {
            List<EntidadVeterinario> listado = daoveterinaria.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }

            return View(listado);
        }
        public ActionResult NuevoVeterinario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AgregarVeterinario(EntidadVeterinario veterinario)
        {
            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daoveterinaria.guardar(veterinario);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del VETERINARIO guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del VETERINARIO porque ya existe..";
                    }

                }
                return RedirectToAction("ListarVeterinario");
                
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoVeterinario");

            }
        }
        public ActionResult editarVeterinario(int id)
        {
            EntidadVeterinario veterinario = daoveterinaria.buscarID(id);
            return View(veterinario);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarVeterinario(EntidadVeterinario veterinario)
        {  //modelstate esdado del modelo
            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daoveterinaria.actualizarveterinario(veterinario);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del VETERINARIO actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del VETERINARIO..";
                    }
                }
                return RedirectToAction("ListarVeterinario");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarVeterinario");
            }
        }
        public ActionResult borrarveterinario(int id)
        {
            EntidadVeterinario veterinario = daoveterinaria.buscarID(id);
            return View(veterinario);
        }
        [HttpPost]
        public ActionResult eliminarveterinario(int id)
        {

            try
            {
                string resultado = daoveterinaria.borrarveterinario(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarVeterinario");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarveterinario");
            }
        }


        public ActionResult ListarCalendario()
        {
            List<EntidadCalendario> listado = daocalendario.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }
            return View(listado);
        }
        public ActionResult NuevoCalendario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AgregarCalendario(EntidadCalendario calendario)
        {
            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daocalendario.guardar(calendario);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del CALENDARIO guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del CALENDARIO porque ya existe..";
                    }
                    
                }
                return RedirectToAction("ListarCalendario");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoCalendario");

            }
        }
        //editar calendario
        public ActionResult editarCalendario(int id)
        {
            EntidadCalendario calendario = daocalendario.buscarID(id);
            return View(calendario);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarCalendario(EntidadCalendario calendario)
        {  //modelstate esdado del modelo
            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daocalendario.actualizarcalendario(calendario);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del CALENDARIO actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del CALENDARIO..";
                    }
                }
                return RedirectToAction("ListarCalendario");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarCalendario");
            }
        }
        //buscar por id para eliminar borrar calendario
        public ActionResult borrarCalendario(int id)
        {
            EntidadCalendario bcalendario = daocalendario.buscarID(id);
            return View(bcalendario);
        }
        [HttpPost]
        public  ActionResult eliminarcalendario( int id)
        {

            try
            {
                string resultado = daocalendario.borrarcalendario(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarCalendario");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarCalendario");
            }
        }

        public ActionResult ListarCliente()
        {
            List<EntidadCliente> listado = daocliente.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }
            return View(listado);
        }
        public ActionResult NuevoCliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(EntidadCliente cliente)
        {
            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daocliente.guardar(cliente);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del CLIENTE guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del CLIENTE porque ya existe..";
                    }

                }
                return RedirectToAction("ListarCliente");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoCliente");

            }
          

        }
        public ActionResult editarCliente(int id)
        {
            EntidadCliente cliente = daocliente.buscarID(id);
            return View(cliente);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarCliente(EntidadCliente cliente)
        {  //modelstate esdado del modelo
            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daocliente.actualizarcliente(cliente);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del CLIENTE actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del CLIENTE..";
                    }
                }
                return RedirectToAction("ListarCliente");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarCliente");
            }
        }
        public ActionResult borrarcliente(int id)
        {
            EntidadCliente cliente = daocliente.buscarID(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult eliminarcliente(int id)
        {

            try
            {
                string resultado = daocliente.borrarcliente(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarCliente");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarcliente");
            }
        }
        public ActionResult ListarHistorial()
        {
            List<EntidadHistorial> listado = daohistorial.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }

            return View(listado);
        }
        public ActionResult NuevoHistorial()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AgregarHistorial(EntidadHistorial historial)
        {
            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daohistorial.guardar(historial);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del HISTORIAL MASCOTA guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del HISTORIAL MASCOTA porque ya existe..";
                    }

                }
                return RedirectToAction("ListarHistorial");
                
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoHistorial");

            }
        }
        public ActionResult editarHistorial(int id)
        {
            EntidadHistorial historial = daohistorial.buscarID(id);
            return View(historial);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarHistorial(EntidadHistorial historial)
        {  //modelstate esdado del modelo
            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daohistorial.actualizarhistorial(historial);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del HISTORIAL actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del HISTORIAL..";
                    }
                }
                return RedirectToAction("ListarHistorial");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarHistorial");
            }
        }
        //buscar por id para eliminar borrar historial
        public ActionResult borrarHistorial(int id)
        {
            EntidadHistorial historial = daohistorial.buscarID(id);
            return View(historial);
        }
        [HttpPost]
        public ActionResult eliminarhistorial(int id)
        {

            try
            {
                string resultado = daohistorial.borrarhistorial(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarHistorial");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarCalendario");
            }
        }

        public ActionResult ListarServicios()
        {
            List<EntidadServicios> listado = daoservicios.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }

            return View(listado);
        }
        public ActionResult NuevoServicios()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AgregarServicios(EntidadServicios servicios)
        {
            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daoservicios.guardar(servicios);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del SERVICIO guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del SERVICIO porque ya existe..";
                    }

                }
                return RedirectToAction("ListarServicios");
                

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoServicios");

            }
        }
        public ActionResult editarservicios(int id)
        {
            EntidadServicios servicios = daoservicios.buscarID(id);
            return View(servicios);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarservicios(EntidadServicios servicios)
        {  //modelstate esdado del modelo

            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daoservicios.actualizarservicios(servicios);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del SERVICIO actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion del SERVICIO..";
                    }
                }
                return RedirectToAction("ListarServicios");
                
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarservicios");
            }
        }
        //buscar por id para eliminar borrar calendario

        public ActionResult borrarservicio(int id)
        {
            EntidadServicios servicios = daoservicios.buscarID(id);
            return View(servicios);
        }
        [HttpPost]
        public ActionResult eliminarservicios(int id)
        {

            try
            {
                string resultado = daoservicios.borrarservicio(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarServicios");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarservicio");
            }
        }

        public ActionResult ListarMascota()
        {
            List<EntidadMascota> listado = daomascota.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }

            return View(listado);
        }
        public ActionResult NuevoMascota()
        {
            List<EntidadCliente> listacliente = daocliente.listar();
            ViewBag.listacliente = listacliente;

            List<EntidadHistorial> listahistorial = daohistorial.listar();
            ViewBag.listahistorial = listahistorial;

            List<EntidadCalendario> listacalendario = daocalendario.listar();
            ViewBag.listacalendario = listacalendario;


            return View();
        }

        [HttpPost]

        public ActionResult AgregarMascota(string nombre, string descripcion, string pesoPromedio, string pesoActual, string fechaNacimiento, int cbocliente, int cbohistorial, int cbocalendario)
        {

            EntidadMascota mascota = new EntidadMascota();
            mascota.nombre = nombre;
            mascota.descripcion = descripcion;
            mascota.pesoPromedio = pesoPromedio;
            mascota.pesoActual = pesoActual;
            mascota.fechaNacimiento = fechaNacimiento;
            mascota.cliente.idcliente = cbocliente;
            mascota.historial.idhistorial = cbohistorial;
            mascota.calendario.idcalendario = cbocalendario;

            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daomascota.guardar(mascota);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion del MASCOTA guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del MASCOTA..";
                    }

                }
                return RedirectToAction("ListarMascota");


            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoMascota");

            }

        }
        public ActionResult editarMascota(int id)
        {
            List<EntidadCliente> listacliente = daocliente.listar();
            ViewBag.listacliente = listacliente;

            List<EntidadHistorial> listahistorial = daohistorial.listar();
            ViewBag.listahistorial = listahistorial;

            List<EntidadCalendario> listacalendario = daocalendario.listar();
            ViewBag.listacalendario = listacalendario;

            EntidadMascota mascota = daomascota.buscarID(id);
            return View(mascota);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarmascota(int idmascota,string nombre, string descripcion, string pesoPromedio, string pesoActual, string fechaNacimiento, int cbocliente, int cbohistorial, int cbocalendario)
        {  //modelstate esdado del modelo
            EntidadMascota mascota = new EntidadMascota();

            mascota.idmascota = idmascota;
            mascota.nombre = nombre;
            mascota.descripcion = descripcion;
            mascota.pesoPromedio = pesoPromedio;
            mascota.pesoActual = pesoActual;
            mascota.fechaNacimiento = fechaNacimiento;
            mascota.cliente.idcliente = cbocliente;
            mascota.historial.idhistorial = cbohistorial;
            mascota.calendario.idcalendario = cbocalendario;
           

            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daomascota.actualizarmascota(mascota);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion del MASCOTA actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion de la MASCOTA..";
                    }
                }
                return RedirectToAction("ListarMascota");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarMascota");
            }
        }
        public ActionResult borrarmascota(int id)
        {
            EntidadMascota mascota = daomascota.buscarID(id);
            return View(mascota);
        }
        [HttpPost]
        public ActionResult eliminarmacota(int id)
        {

            try
            {
                string resultado = daomascota.borrarmascota(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarMascota");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarmascota");
            }
        }
        public ActionResult ListarCitas()
        {
            List<EntidadCitas>listado =daocitas.listar();
            if (listado.Count == 0)
            {
                TempData["InfoMessage"] = "Actualmente los datos no estan disponibles en la BD.";
            }
            return View(listado);
        }
        public ActionResult NuevoCitas()
        {
            List<EntidadCliente> listacliente = daocliente.listar();
            ViewBag.listacliente = listacliente;

            List<EntidadServicios> listaservicios = daoservicios.listar();
            ViewBag.listaservicios = listaservicios;

            List<EntidadMascota> listamascota = daomascota.listar();
            ViewBag.listamascota = listamascota;

            List<EntidadVeterinario> listaveterinario = daoveterinaria.listar();
            ViewBag.listaveterinario = listaveterinario;

            return View();
        }

        [HttpPost]

        public ActionResult AgregarCitas(string fechar, string hora, string estado, int cbocliente, int cboservicio, int cbomascota, int cboveterinario)
        {

            EntidadCitas citas = new EntidadCitas();
            citas.fechar = fechar;
            citas.hora = hora;
            citas.estado = estado;
            citas.cliente.idcliente = cbocliente;
            citas.servicios.idservicios = cboservicio;
            citas.mascota.idmascota = cbomascota;
            citas.veterinario.idveterinario = cboveterinario;

            bool inserta = false;
            try
            {
                if (ModelState.IsValid)
                {
                    inserta = daocitas.guardar(citas);
                    if (inserta)
                    {
                        TempData["SuccessMessage"] = "Informacion de la CITA guardado correctamente..";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo guardar informacion del CITA..";
                    }

                }
                return RedirectToAction("ListarCitas");


            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("NuevoCitas");

            }

        }
        public ActionResult editarCitas(int id)
        {
            List<EntidadCliente> listacliente = daocliente.listar();
            ViewBag.listacliente = listacliente;

            List<EntidadServicios> listaservicios = daoservicios.listar();
            ViewBag.listaservicios = listaservicios;

            List<EntidadMascota> listamascota = daomascota.listar();
            ViewBag.listamascota = listamascota;

            List<EntidadVeterinario> listaveterinario = daoveterinaria.listar();
            ViewBag.listaveterinario = listaveterinario;

            EntidadCitas citas = daocitas.buscarID(id);
            return View(citas);
        }
        //actualizar 
        [HttpPost]
        public ActionResult actualizarcitas(int idcitas, string fechar, string hora, string estado, int cbocliente, int cboservicio, int cbomascota, int cboveterinario)
        {  //modelstate esdado del modelo
            EntidadCitas citas = new EntidadCitas();

            citas.idcitas = idcitas;
            citas.fechar = fechar;
            citas.hora = hora;
            citas.estado = estado;
            citas.cliente.idcliente = cbocliente;
            citas.servicios.idservicios = cboservicio;
            citas.mascota.idmascota = cbomascota;
            citas.veterinario.idveterinario = cboveterinario;


            try
            {
                if (ModelState.IsValid)
                {
                    bool seactualiza = daocitas.actualizarcitas(citas);
                    if (seactualiza)
                    {
                        TempData["SecondaryMessage"] = "Informacion de la CITA actualizado correctamente..";
                    }
                    else
                    {
                        TempData["InfoMessage"] = "No se llego a Actualizar informacion de la CITA..";
                    }
                }
                return RedirectToAction("ListarCitas");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("editarCitas");
            }
        }
        public ActionResult borrarcita(int id)
        {
            EntidadCitas citas = daocitas.buscarID(id);
            return View(citas);
        }
        [HttpPost]
        public ActionResult eliminarcita(int id)
        {

            try
            {
                string resultado = daocitas.borrarcitas(id);
                if (resultado.Contains("eliminado"))
                {
                    TempData["PrimaryMessage"] = resultado;
                }
                else
                {
                    TempData["ErrorMessage"] = resultado;
                }
                return RedirectToAction("ListarCitas");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("borrarcita");
            }
        }
    }
}