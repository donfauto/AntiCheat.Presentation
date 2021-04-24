using BlogCore.AccesoDatos.Data.Repository;
using BlogCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        //----------------------//
        //-------INDEX----------//
        //----------------------//
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //----------------------//
        //-------CREATE---------//
        //----------------------//
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            var buscar = _contenedorTrabajo.Categoria.GetFirstOrDefault(u => u.Nombre != null);
            if (ModelState.IsValid)
            {
                if (categoria.Nombre == buscar.Nombre)
                {
                    TempData["msg"] = "<div class='alert alert-danger dismissible fade show'>¡Ha habido un error! ya existe una categoría con este nombre.</div>";
                }
                else
                {
                    _contenedorTrabajo.Categoria.Add(categoria);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                   
                }
            }
            return View(categoria);
            
        }

        //----------------------//
        //-------EDITAR---------//
        //----------------------//
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);

        }


        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            
            }
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoria borrada" });
        }
        #endregion

       
    }
}
