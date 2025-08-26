using Microsoft.AspNetCore.Mvc;
using Phoenix.Models;
using Phoenix.BLL.Interfaces;

namespace Phoenix.Controllers
{
    public class PartenerController : Controller
    {
        private readonly IPartenerService _service;

        public PartenerController(IPartenerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var parteneri = _service.GetAll();

            // Mapăm entitățile la modele simple (aici poți folosi AutoMapper, dar simplu manual):
            var model = parteneri.Select(p => new PartenerModel
            {                
                Denumire = p.Denumire
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PartenerModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new Phoenix.BLL.Models.Partener
                {
                    Denumire = model.Denumire
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
