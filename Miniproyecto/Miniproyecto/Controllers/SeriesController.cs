using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.Models;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using MiniProyecto.Web.Models;
using System.Collections.Generic;

namespace Miniproyecto.Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISeriesService _serieService;
        private readonly ICategoriaService _categoriaService;
        private readonly IGeneroService _generoService;
        private readonly IProductorService _productorService;

        public SeriesController(ISeriesService serieService, ICategoriaService categoriaService, IGeneroService generoService, IProductorService productorService)
        {
            _serieService = serieService;
            _categoriaService = categoriaService;
            _generoService = generoService;
            _productorService = productorService;
        }

        // GET: SerieController
        public ActionResult Index()
        {
            var serieData = _serieService.GetAll().Data as List<MiniProyecto.BLL.Models.SeriesModel>;
           var serieModels = new List<MiniProyecto.Web.Models.SeriesModel>();

            if (serieData != null)
            {
                serieModels = serieData.Select(s => new MiniProyecto.Web.Models.SeriesModel
                {
                    SerieID = s.SerieID,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Imagen = s.Imagen,
                    IDcategoria = s.IDcategoria,
                    IDproductor = s.IDproductor,
                    IDgenero = s.IDgenero,
                    IDgenero2 = s.IDgenero2,
                    URL = s.URL
                    
                }).ToList();
            }

            return View(serieModels);
        }

        // GET: SerieController/Details/5
        public ActionResult Details(int id)
        {
            var serieResult = _serieService.GetById(id);
            if (serieResult.Success)
            {
                var serie = (MiniProyecto.BLL.Models.SeriesModel)serieResult.Data;
                var serieViewModel = new MiniProyecto.Web.Models.SeriesModel()
                {
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDcategoria = serie.IDcategoria,
                    IDproductor = serie.IDproductor,
                    IDgenero = serie.IDgenero,
                    IDgenero2 = serie.IDgenero2,
                    URL = serie.URL

                };
                return View(serieViewModel);
            }
            else
            {
                return View("Serie no encontrada");
            }
        }

        // GET: SerieController/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = _categoriaService.GetAll().Data;
            ViewBag.Generos = _generoService.GetAll().Data;
            ViewBag.Productores = _productorService.GetAll().Data;
            return View();
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MiniProyecto.DAL.Entities.Series serie)
        {
            try
            {
                MiniProyecto.BLL.Dtos.SeriesDTO serieToSave = new MiniProyecto.BLL.Dtos.SeriesDTO()
                {
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDcategoria = serie.IDcategoria,
                    IDproductor = serie.IDproductor,
                    IDgenero = serie.IDgenero,
                    IDgenero2 = serie.IDgenero2,
                    URL = serie.URL

                };
                _serieService.Save(serieToSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SerieController/Edit/5
        public ActionResult Edit(int id)
        {
            var serieResult = _serieService.GetById(id);
            if (serieResult.Success)
            {
                var serie = (MiniProyecto.BLL.Models.SeriesModel)serieResult.Data;
                var serieViewModel = new MiniProyecto.Web.Models.SeriesModel()
                {
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDcategoria = serie.IDcategoria,
                    IDproductor = serie.IDproductor,
                    IDgenero = serie.IDgenero,
                    IDgenero2 =serie.IDgenero2,
                          URL = serie.URL

                };
                ViewBag.Categorias = _categoriaService.GetAll().Data;
                ViewBag.Generos = _generoService.GetAll().Data;
                ViewBag.Productores = _productorService.GetAll().Data;
                return View(serieViewModel);
            }
            else
            {
                return View("Serie no encontrada");
            }
        }

        // POST: SerieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MiniProyecto.Web.Models.SeriesModel serie)
        {
            try
            {
                MiniProyecto.BLL.Dtos.SeriesDTO serieToUpdate = new MiniProyecto.BLL.Dtos.SeriesDTO()
                {
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDcategoria = serie.IDcategoria,
                    IDproductor = serie.IDproductor,
                    IDgenero = serie.IDgenero,
                    IDgenero2 = serie.IDgenero2,
                    URL = serie.URL
                    
                };
                _serieService.Update(serieToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SerieController/Delete/5
        public ActionResult Delete(int id)
        {
            var serieResult = _serieService.GetById(id);
            if (serieResult.Success)
            {
                var serie = (MiniProyecto.BLL.Models.SeriesModel)serieResult.Data;
                var serieViewModel = new MiniProyecto.Web.Models.SeriesModel()
                {
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDcategoria = serie.IDcategoria,
                    IDproductor = serie.IDproductor,
                    IDgenero = serie.IDgenero,
                    IDgenero2 = serie.IDgenero2,
                          URL = serie.URL
                };
                return View(serieViewModel);
            }
            else
            {
                return View("Serie no encontrada");
            }
        }

        // POST: SerieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MiniProyecto.Web.Models.SeriesModel serie)
        {
            try
            {
                MiniProyecto.BLL.Dtos.SeriesDTO seriesDTO = new MiniProyecto.BLL.Dtos.SeriesDTO
                {
                    IDcategoria = serie.IDcategoria,
                    IDgenero = serie.IDgenero,
                    Descripcion = serie.Descripcion,
                    IDproductor = serie.IDproductor,
                    Imagen = serie.Imagen,
                    SerieID = serie.SerieID,
                    Nombre = serie.Nombre,
                    IDgenero2 = serie.IDgenero2,
                    URL = serie.URL


                };
                _serieService.Remove(seriesDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}