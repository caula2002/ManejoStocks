using ClosedXML.Excel;
using ManejoStocks.Data;
using ManejoStocks.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManejoStocks.Controllers
{
    public class ImportarExelProductos : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImportarExelProductos(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubirExcel(IFormFile excel)
        {
            try
            {
                var workbook = new XLWorkbook(excel.OpenReadStream());
                var hoja = workbook.Worksheet(1);
                var primeraFila = hoja.FirstRowUsed().RangeAddress.FirstAddress.RowNumber;
                var ultimaFila = hoja.LastRowUsed().RangeAddress.LastAddress.RowNumber;
                List<Productos> productos = new List<Productos>();
                for (int i = primeraFila; i <= ultimaFila; i++)
                {
                    var fila = hoja.Row(i);
                    Productos producto = new Productos();
                    producto.Codigo = fila.Cell(1).GetString();
                    producto.Nombre = fila.Cell(2).GetString();
                    producto.Categoria = fila.Cell(3).GetString();
                    productos.Add(producto);
                }
                _context.Productos.AddRange(productos);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction("Index", "Producto");
        }
    }
}
