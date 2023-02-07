using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Lote")]
    [Index("Articulo", "Proveedor", "SubOrdenProduccion", "NumeroLote", Name = "IX_Lote1_1")]
    [Index("IndicadorMov", "Proveedor", Name = "IndicadorProveedor")]
    [Index("IndicadorMov", "SubOrdenProduccion", Name = "IndicadorSubOrden")]
    [Index("Codigo", "Articulo", Name = "LoteArticulo")]
    public partial class Lote
    {
        public Lote()
        {
            Existencia = new HashSet<Existencia>();
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? Descripcion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaVencimiento { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ValorTotal { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? CantidadTotal { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Proveedor { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Articulo { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? SubOrdenProduccion { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string IndicadorMov { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? NumeroLote { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioBruto { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioNeto { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioNetoEmpaque { get; set; }
        public bool? Deshabilitado { get; set; }
        [StringLength(8000)]
        [Unicode(false)]
        public string? Formulacantidad { get; set; }
        [StringLength(8000)]
        [Unicode(false)]
        public string? Formulavalor { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CantidadFormulada { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorFormulado { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Peso { get; set; }
        [StringLength(8000)]
        [Unicode(false)]
        public string? FormulaPeso { get; set; }
        public byte? ConfiguracionCantidad { get; set; }
        public byte? ConfiguracionValor { get; set; }
        public bool? NoPermitirSalidasParciales { get; set; }
        public bool? LoteConMovimiento { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? LoteClasificacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LoteDependencia { get; set; }
        [Column("sdtFechaElaboracion", TypeName = "smalldatetime")]
        public DateTime? SdtFechaElaboracion { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("Iden_lote")]
        public int IdenLote { get; set; }
        public bool? Aprobar { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Estado { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? PersonalAprueba { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DocumentoGenerado { get; set; }
        public bool? BloqueoRangoFecha { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? BloqueoFechaInicial { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? BloqueoFechaFinal { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? MotivoBloqueoRangoFecha { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaDeBloqueoRangoFecha { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? UsuarioDeBloqueoRangoFecha { get; set; }

        [InverseProperty("LoteNavigation")]
        public virtual ICollection<Existencia> Existencia { get; set; }
        [InverseProperty("LoteNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
