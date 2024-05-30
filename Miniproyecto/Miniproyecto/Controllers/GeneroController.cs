using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Models;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Miniproyecto.Web.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        // GET: GeneroController
        public ActionResult Index()
        {
            var generoData = _generoService.GetAll().Data as List<MiniProyecto.BLL.Models.GeneroModel>;
            var generoModels = new List<MiniProyecto.Web.Models.GeneroModel>();

            if (generoData != null)
            {
                generoModels = generoData.Select(g => new MiniProyecto.Web.Models.GeneroModel()
                {
                    IDgenero = g.IDgenero,
                    Tipo = g.Tipo
                }).ToList();
            }

            return View(generoModels);
        }

        // GET: GeneroController/Details/5
        public ActionResult Details(int id)
        {
            var generoResult = _generoService.GetById(id);
            if (generoResult.Success)
            {
                var genero = (MiniProyecto.BLL.Models.GeneroModel)generoResult.Data;
                var generoViewModel = new MiniProyecto.Web.Models.GeneroModel()
                {
                    IDgenero = genero.IDgenero,
                    Tipo = genero.Tipo
                };
                return View(generoViewModel);
            }
            else
            {
                return View("Género no encontrado");
            }
        }

        // GET: GeneroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                GeneroDTO generosave = new GeneroDTO()
                {
                    IDgenero = genero.IDgenero,
                    Tipo = genero.Tipo
                };
                _generoService.Save(generosave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneroController/Edit/5
        public ActionResult Edit(int id)
        {
            var generoResult = _generoService.GetById(id);
            if (generoResult.Success)
            {
                var genero = (MiniProyecto.BLL.Models.GeneroModel)generoResult.Data;
                var generoViewModel = new MiniProyecto.Web.Models.GeneroModel()
                {
                    IDgenero = genero.IDgenero,
                    Tipo = genero.Tipo
                };
                return View(generoViewModel);
            }
            else
            {
                return View("Género no encontrado");
            }
        }

        // POST: GeneroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {
            try
            {
                GeneroDTO generoUpdate = new GeneroDTO()
                {
                    IDgenero = genero.IDgenero,
                    Tipo = genero.Tipo
                };
                _generoService.Update(generoUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GeneroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GeneroController/Delete/5
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