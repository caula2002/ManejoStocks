using ManejoStocks.Models;

namespace ManejoStocks.ViewsModels
{
    public class UsuariosViewModel
    {
        public List<Usuarios>? Usuarios { get; set; }
    }
    public class ProductosViewModel
    {
        public List<Productos>? Productos { get; set; }
        public string? buscarNombre { get; set; }
    }
    public class StockViewModel
    {
        public List<Stock>? Stocks { get; set; }
        public string? buscarNombre { get; set; }
        public bool MostrarSoloBajosStocks { get; set; }
    }
}
