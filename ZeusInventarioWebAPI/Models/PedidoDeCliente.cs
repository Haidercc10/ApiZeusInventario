using System;
using System.Collections.Generic;

namespace ZeusInventarioWebAPI;

public partial class PedidoDeCliente
{
    public decimal Consecutivo { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime FechaEntrega { get; set; }

    public string Estado { get; set; } = null!;

    public string? Cliente { get; set; }

    public string Vendedor { get; set; } = null!;

    public string? Detalle { get; set; }

    public bool? Anticipo { get; set; }

    public string? CuentaAnticipo { get; set; }

    public string? Auxiliar { get; set; }

    public decimal? ValorAnticipo { get; set; }

    public string? FormaPago { get; set; }

    public decimal? NumeroCuotas { get; set; }

    public decimal? DiasCreditos { get; set; }

    public DateTime? VencimientoInicial { get; set; }

    public string? CuentaPago { get; set; }

    public string Moneda { get; set; } = null!;

    public decimal Tasacambio { get; set; }

    public string? CentroCosto { get; set; }

    public decimal? Usuario { get; set; }

    public decimal? DocumentoRev { get; set; }

    public string? OrdenCompraCliente { get; set; }

    public string? AutorOrdenCompra { get; set; }

    public decimal? Aprueba { get; set; }

    public string Clasificacion { get; set; } = null!;

    public string? ListaDePrecios { get; set; }

    public string? DespachoCliente { get; set; }

    public string? DespachoDireccion { get; set; }

    public string? DespachoCiudad { get; set; }

    public string? DespachoTransportadora { get; set; }

    public string? ObservacionInterna { get; set; }

    public string? ModalidadVentas { get; set; }

    public decimal? Aplicacion { get; set; }

    public decimal? TipoDocumentoExterno { get; set; }

    public decimal? ConsecutivoExterno { get; set; }

    public string? Caja { get; set; }

    public int? TipoBloqueo { get; set; }

    public bool? AprobadoPorEstudioCartera { get; set; }

    public string? ObservacionesDeAprobacion { get; set; }

    public decimal? FletePorUnidad { get; set; }

    public bool? RealizadoDispositivoMovil { get; set; }

    public bool? Plantilla { get; set; }

    public decimal? Preaprueba { get; set; }

    public bool? YaFueAnalizadaPr { get; set; }

    public bool? DescartarPuntoReorden { get; set; }

    public int IdenPedidodecliente { get; set; }
}
