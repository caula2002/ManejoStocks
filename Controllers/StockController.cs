using ManejoStocks.Data;
using ManejoStocks.Models;
using ManejoStocks.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManejoStocks.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: StockController

        public async Task<IActionResult> Index(string buscarNombre, bool mostrarSoloBajoStock = false)
        {
            // Genero los filtros
            var query = _context.Stocks.Include(s => s.Productos).AsQueryable();
            if (!string.IsNullOrEmpty(buscarNombre))
            {
                query = query.Where(x => x.Productos != null && x.Productos.Nombre.Contains(buscarNombre));
            }
            if (mostrarSoloBajoStock)
            {
                query = query.Where(x => x.Cantidad < x.CantidadMinima);
            }

            // Generar el modelo
            var modelo = new StockViewModel()
            {
                Stocks = await query.ToListAsync(),
                buscarNombre = buscarNombre,
                MostrarSoloBajosStocks = mostrarSoloBajoStock
            };
            return View(modelo);
        }

        // GET: StockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: StockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: StockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockController/Delete/5
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
