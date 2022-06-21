using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("FacturaDeCliente")]
    [Index("DocumentoRev", Name = "IX_FacturaDeCliente")]
    [Index("Cliente", Name = "IX_FacturaDeCliente_Cliente")]
    [Index("Vendedor", Name = "IX_FacturaDeCliente_Vendedor")]
    public partial class FacturaDeCliente
    {
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Consecutivo { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string Fuente { get; set; } = null!;
        [StringLength(5)]
        [Unicode(false)]
        public string Serie { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string? Documento { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;
        [StringLength(25)]
        [Unicode(false)]
        public string? Cliente { get; set; }
        [StringLength(3)]
        [Unicode(false)]
        public string Vendedor { get; set; } = null!;
        [Column("detalle")]
        [StringLength(2000)]
        [Unicode(false)]
        public string? Detalle { get; set; }
        [Required]
        public bool? Anticipo { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaAnticipo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Auxiliar { get; set; }
        [Column(TypeName = "money")]
        public decimal? ValorAnticipo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FormaPago { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? NumeroCuotas { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasCreditos { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? VencimientoInicial { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaPago { get; set; }
        [StringLength(3)]
        [Unicode(false)]
        public string Moneda { get; set; } = null!;
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Tasacambio { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? CentroCosto { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Usuario { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DocumentoRev { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ComisionLiquidada { get; set; }
        [StringLength(6)]
        [Unicode(false)]
        public string? PeriodoComisionLiquidada { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? ListaDePrecios { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Despachocliente { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? DespachoDireccion { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? DespachoCiudad { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? DespachoTransportadora { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string TipoFactura { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string? ObservacionInterna { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string? ModalidadVentas { get; set; }
        [Column("NCF")]
        [StringLength(25)]
        [Unicode(false)]
        public string? Ncf { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaCaducidad { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? EntregadeFactura { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? FletePorUnidad { get; set; }
        public bool? ProvisionGarantia { get; set; }
        public bool? Cortesia { get; set; }
        public bool? ControlEntrega { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? EstadoEntrega { get; set; }
        public bool? SujetoDetraccion { get; set; }
        public bool? DetraccionAutomatica { get; set; }
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
        [Column(TypeName = "smalldatetime")]
        public DateTime? VencimientoDetraccion { get; set; }
        [Column("Iden_facturadecliente")]
        public int IdenFacturadecliente { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? NumeroFactura { get; set; }

        [ForeignKey("ModalidadVentas")]
        [InverseProperty("FacturaDeClientes")]
        public virtual ModalidadesVenta? ModalidadVentasNavigation { get; set; }
    }
}
