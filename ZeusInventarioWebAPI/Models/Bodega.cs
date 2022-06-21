using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Bodega")]
    public partial class Bodega
    {
        public Bodega()
        {
            Existencia = new HashSet<Existencia>();
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string? Ciudad { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Direccion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Telefonos { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? CodigoAuxiliar { get; set; }
        public bool Excluir { get; set; }
        [Column("auxiliarcosto")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Auxiliarcosto { get; set; }
        [Column("auxiliarventa")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Auxiliarventa { get; set; }
        [Column("auxiliariva")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Auxiliariva { get; set; }
        public bool? IncluirCalculoReorden { get; set; }
        public bool? BodegaPrincipal { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarInventarioxEntregar { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarInventarioRemisionado { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarCentroCosto { get; set; }
        [Column("AuxiliarIVAVentas")]
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarIvaventas { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AuxiliarAjusteInflacion { get; set; }
        [Column("AuxiliarIVAConsumo")]
        [StringLength(50)]
        [Unicode(false)]
        public string? AuxiliarIvaconsumo { get; set; }
        public bool? NoAplicarAjusteInflacion { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarPartidaAjusteInflacion { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDevolucionVentas { get; set; }
        [Column("AuxiliarIVADevolucionVentas")]
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarIvadevolucionVentas { get; set; }
        [Column("BU")]
        [StringLength(25)]
        [Unicode(false)]
        public string? Bu { get; set; }
        public bool? SalidaporBascula { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarImpoconCompras { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarImpoconDevolucionCompras { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarImpoconVentas { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarImpoconDevolucionVentas { get; set; }
        [Column("ComprasNoDescuentanIVA")]
        public bool? ComprasNoDescuentanIva { get; set; }
        public bool? BodegaImportacion { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad1 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad2 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad3 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad4 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad5 { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarIngresoDescFinancieroEnCompras { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarGastoDescFinancieroEnVenta { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDevolucionPorGarantia { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarProvisionGarantia { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDescuentoVenta { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarRemisionReconocimientoIngreso { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ConceptoCostoEstandar { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ConceptoCostoEstandarProdProceso { get; set; }
        public bool? EsCasino { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? SolicitantePorDefecto { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? CostoVenta { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? TipofacturaCarteraRemisionada { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasMaximo { get; set; }
        public bool? ParticipaEnLiquidacion { get; set; }
        [Column("Iden_bodega")]
        public int IdenBodega { get; set; }
        public bool? ValidaLote { get; set; }

        [InverseProperty("BodegaNavigation")]
        public virtual ICollection<Existencia> Existencia { get; set; }
        [InverseProperty("BodegaNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
