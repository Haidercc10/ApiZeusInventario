using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models;

[Index("Proveedor", Name = "IX_Entrada")]
[Index("Fecha", Name = "IX_Entrada_1")]
[Index("Estado", Name = "IX_Entrada_2")]
[Index("FacturaProveedor", Name = "IX_Entrada_3")]
[Index("NumeroDocumento", Name = "IX_Entrada_4")]
[Index("TipoFactura", "FacturaProveedor", "Referenciafactura", Name = "IX_Entrada_5")]
[Index("Legalizacion", Name = "IX_Entrada_Legalizacion")]
public partial class Entradum
{
    [Key]
    [Column(TypeName = "numeric(18, 0)")]
    public decimal Consecutivo { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? TipoDocumento { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Anotaciones { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? NumeroDocumento { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Fecha { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? GeneradaPor { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Fuente { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Serie { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Documento { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Usuario { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Proveedor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FacturaProveedor { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? DiasCredito { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Vencimiento { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? TipoFactura { get; set; }

    [Column(TypeName = "numeric(18, 6)")]
    public decimal? TasaCambio { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? Moneda { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaFactura { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? NoSerie { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NoAutorizacion { get; set; }

    [Column("NCF")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Ncf { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCaducidad { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? NoSerieComprobanteRetencion { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? SecuencialComprobanteRetencion { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? AutorizacionComprobanteRetencion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaEmisionComprobanteRetencion { get; set; }

    public bool? Provisionproveedores { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? ReciboFactura { get; set; }

    [Column("Iden_EntradaCompraPresupuesto", TypeName = "numeric(18, 0)")]
    public decimal? IdenEntradaCompraPresupuesto { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? ConsecutivoEntradaGeneradora { get; set; }

    public bool? Anticipo { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? CuentaAnticipo { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Auxiliar { get; set; }

    [Column(TypeName = "money")]
    public decimal? ValorAnticipo { get; set; }

    public bool? Legalizacion { get; set; }

    [Column("REFERENCIAFACTURA")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Referenciafactura { get; set; }

    public bool? EsEntradaComprasMenores { get; set; }

    [Column("NCF_ComprasMenores")]
    [StringLength(25)]
    [Unicode(false)]
    public string? NcfComprasMenores { get; set; }

    public bool? ParaPorcionamiento { get; set; }

    public bool? ManejaCuentaCajaMenor { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? CuentaCajaMenor { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Nit { get; set; }

    public bool? SujetoDetraccion { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? TipoOperacionCodigo { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? BienesServiciosCodigo { get; set; }

    [Column(TypeName = "numeric(18, 6)")]
    public decimal? PorcentajeDetraccion { get; set; }

    [Column(TypeName = "numeric(18, 6)")]
    public decimal? ImporteDetraccion { get; set; }

    public bool? PagoDetraccionProveedor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NumeroDeposito { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDeposito { get; set; }

    public bool? Expres { get; set; }

    [Column(TypeName = "numeric(18, 6)")]
    public decimal? DescuentoGlobal { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? AjusteBonificado { get; set; }

    public bool? TransformacionAutomatica { get; set; }

    [Column("Iden_entrada")]
    public int IdenEntrada { get; set; }

    public bool? DetraccionAutomatica { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? VencimientoDetraccion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaEmisionLiquidacionCompra { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? NoSerieLiquidacionCompra { get; set; }

    [Column("NCFLiquidacionCompra")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NcfliquidacionCompra { get; set; }
}
