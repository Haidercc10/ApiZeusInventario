using System;
using System.Collections.Generic;

namespace ZeusInventarioWebAPI.Models;

public partial class DevolucionVenta
{
    public decimal Consecutivo { get; set; }

    public string Fuente { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string? Documento { get; set; }

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public string? Cliente { get; set; }

    public string Vendedor { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public bool Anticipo { get; set; }

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

    public string? NumeroFactura { get; set; }

    public string TipoFactura { get; set; } = null!;

    public string? ModalidadVentas { get; set; }

    public string? Ncf { get; set; }

    public string? NcfModificado { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public bool? EntregaMercanciaAutomatica { get; set; }

    public int IdenDevolucionventas { get; set; }

    public bool? Cortesia { get; set; }

    public bool? IngresoFactura { get; set; }
}
