namespace ManejoStocks.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int CantidadMinima { get; set; }
        public Productos Productos { get; set; }
    }
}
