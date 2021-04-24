using BlogCore.AccesoDatos.Data.Repository;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(estado => estado.Estado == true),
                ListaArticulo = _contenedorTrabajo.Articulo.GetAll()
            };
            ViewBag.DetallesCategoria = _contenedorTrabajo.Categoria.GetAll();
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //MOSTRAR VISTA DETALLE//
        //----------------------//
        //-------DETALLE--------//
        //----------------------//
        [HttpGet]
        public IActionResult Details(int id)
        {

            var articuloDesdeDb = _contenedorTrabajo.Articulo.GetFirstOrDefault(a => a.Id == id);
            
            if (articuloDesdeDb == null )
            {
                return NotFound();
            }
            ViewBag.Detalles = _contenedorTrabajo.Articulo.GetAll(a => a.CategoriaId == articuloDesdeDb.CategoriaId);
            ViewBag.DetallesCategoria = _contenedorTrabajo.Categoria.GetAll(a => a.Id == articuloDesdeDb.CategoriaId);

            return View(articuloDesdeDb);
        }
    }
}
