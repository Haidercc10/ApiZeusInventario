namespace ZeusInventarioWebAPI.Models.Dto
{
    /// <summary>
    /// Producto (código de artículo + presentación Zeus: UND, KLS, PAQ...) cuyo disponible se desea consultar.
    /// </summary>
    public class ExistenciaProductoConsulta
    {
        public string Producto { get; set; } = null!;
        public string Presentacion { get; set; } = null!;
    }
}
