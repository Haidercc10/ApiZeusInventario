using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Grupo")]
    [Index("Padre", Name = "Grupo")]
    public partial class Grupo
    {
        public Grupo()
        {
            Articulos = new HashSet<Articulo>();
            InversePadreNavigation = new HashSet<Grupo>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Consecutivo { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string? Descripcion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Padre { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? CodigoAuxiliar { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Concepto { get; set; }
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
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaGastoProvision { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarInventarioxEntregar { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarInventarioRemisionado { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarCentroCosto { get; set; }
        [Column("AuxiliarIVAventas")]
        [StringLength(30)]
        [Unicode(false)]
        public string? AuxiliarIvaventas { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PorcentajeComision { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AuxiliarAjusteInflacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AsignacionBodega { get; set; }
        [Column("AuxiliarIVAConsumo")]
        [StringLength(50)]
        [Unicode(false)]
        public string? AuxiliarIvaconsumo { get; set; }
        public bool? NoAplicarAjusteInflacion { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarPartidaAjusteInflacion { get; set; }
        public bool? Virtual { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDevolucionVentas { get; set; }
        [Column("AuxiliarIVADevolucionVentas")]
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarIvadevolucionVentas { get; set; }
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
        public bool? NoModificarTrasfAuto { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("Iden_grupo")]
        public int IdenGrupo { get; set; }
        [Column("Iden_FT_FichaTecnica", TypeName = "numeric(18, 0)")]
        public decimal? IdenFtFichaTecnica { get; set; }

        [ForeignKey("Padre")]
        [InverseProperty("InversePadreNavigation")]
        public virtual Grupo? PadreNavigation { get; set; }
        [InverseProperty("GrupoNavigation")]
        public virtual ICollection<Articulo> Articulos { get; set; }
        [InverseProperty("PadreNavigation")]
        public virtual ICollection<Grupo> InversePadreNavigation { get; set; }
    }
}
