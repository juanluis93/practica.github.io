using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.Models;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Miniproyecto.Web.Controllers
{
    public class ProductorController : Controller
    {
        private readonly IProductorService _productorService;
        private readonly ICategoriaService _categoriaService;
        private readonly IGeneroService     _generoService;
        private readonly ISeriesService _SerieService;

        public ProductorController(IProductorService productorService, ICategoriaService categoriaService, IGeneroService generoService, ISeriesService SerieService)
        {
            _productorService = productorService;
            _categoriaService = categoriaService;
            _generoService = generoService;
            _SerieService = SerieService;


        }


        // GET: ProductorController
        public ActionResult Index()
        {
            var productorData = _productorService.GetAll().Data as List<MiniProyecto.BLL.Models.ProductorModel>;
            var productorModels = new List<Miniproyecto.Models.ProductorModel>();

            if (productorData != null)
            {
                productorModels = productorData.Select(cd => new Miniproyecto.Models.ProductorModel()
                {
                    Apellido = cd.Apellido,
                    Nombre = cd.Nombre,
                  IDproductor = cd.IDproductor,
                  Empresa = cd.Empresa,
              
                  
                  
                }).ToList();
            }

            return View(productorModels);
        }

        // GET: ProductorController/Details/5
        public ActionResult Details(int id)
        {
            var productorResult = _productorService.GetById(id);
            if (productorResult.Success)
            {
                var productor = (MiniProyecto.BLL.Models.ProductorModel)productorResult.Data;
                var productorViewModel = new Miniproyecto.Models.ProductorModel()
                {
                    Apellido = productor.Apellido,
                    Nombre = productor.Nombre,
                    Empresa = productor.Empresa,
                    IDproductor = productor.IDproductor

                };
                return View(productorViewModel);
            }
            else
            {
                return View("Productor no encontrado");
            }
        }

        // GET: ProductorController/Create
        public ActionResult Create()
        {
            ViewBag.Productor = _productorService.GetAll().Data;
            return View();
        }

        // POST: ProductorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productor productor)
        {
            try
            {
                MiniProyecto.BLL.Dtos.ProductorDTO productorSave = new MiniProyecto.BLL.Dtos.ProductorDTO()
                {
                    Apellido = productor.Apellido,
                    Nombre = productor.Nombre,
                    Empresa = productor.Empresa,
                    IDproductor = productor.IDproductor
                  
                };
                _productorService.Save(productorSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductorController/Edit/5
        public ActionResult Edit(int id)
        {
            var productorResult = _productorService.GetById(id);
            if (productorResult.Success)
            {
                var productor = (MiniProyecto.BLL.Models.ProductorModel)productorResult.Data;
                var productorViewModel = new Miniproyecto.Models.ProductorModel()
                {
                    Apellido = productor.Apellido,
                    Nombre = productor.Nombre,
                    Empresa = productor.Empresa,
                    IDproductor = productor.IDproductor,
              
                };
                return View(productorViewModel);
            }
            else
            {
                return View("Productor no encontrado");
            }
        }

        // POST: ProductorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Productor productor)
        {
            try
            {
                MiniProyecto.BLL.Dtos.ProductorDTO productorUpdate = new MiniProyecto.BLL.Dtos.ProductorDTO()
                {
                    Apellido = productor.Apellido,
                    Nombre = productor.Nombre,
                    Empresa = productor.Empresa,
                    IDproductor = productor.IDproductor,
                   
                };
                _productorService.Update(productorUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}