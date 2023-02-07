using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models
{
    [Index("Articulo", Name = "Articulo")]
    [Index("Bodega", "Articulo", Name = "BodegaArticulo")]
    [Index("Lote", "Articulo", Name = "ExistenciaLoteArticulo")]
    [Index("Articulo", "Lote", "Bodega", "Clasificacion", "Ubicacion", Name = "IX_Existencia", IsUnique = true)]
    [Index("Codigo", Name = "IX_Existencia_1")]
    public partial class Existencia
    {
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Codigo { get; set; }
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Articulo { get; set; }
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Lote { get; set; } = null!;
        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Bodega { get; set; } = null!;
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Clasificacion { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Existencias { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Disponibles { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Valor { get; set; }
        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Ubicacion { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Serial { get; set; } = null!;
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorSinInflacion { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Valor2 { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;

        [ForeignKey("Articulo")]
        [InverseProperty("Existencia")]
        public virtual Articulo ArticuloNavigation { get; set; } = null!;
        [ForeignKey("Bodega")]
        [InverseProperty("Existencia")]
        public virtual Bodega BodegaNavigation { get; set; } = null!;
        [ForeignKey("Clasificacion")]
        [InverseProperty("Existencia")]
        public virtual Clasificacion ClasificacionNavigation { get; set; } = null!;
        [ForeignKey("Lote")]
        [InverseProperty("Existencia")]
        public virtual Lote LoteNavigation { get; set; } = null!;
        [ForeignKey("Ubicacion")]
        [InverseProperty("Existencia")]
        public virtual Ubicacion UbicacionNavigation { get; set; } = null!;
    }
}
