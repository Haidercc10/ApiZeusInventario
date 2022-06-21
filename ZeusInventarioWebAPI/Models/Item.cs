using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Index("Lote", Name = "IX_Items_2")]
    [Index("Bodega", Name = "IX_Items_Alfo20180910_Transito")]
    [Index("Articulo", Name = "Items_Articulo")]
    public partial class Item
    {
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Codigo { get; set; }
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Articulo { get; set; }
        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Bodega { get; set; } = null!;
        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Ubicacion { get; set; } = null!;
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Lote { get; set; } = null!;
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Clasificacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Serial { get; set; } = null!;
        public byte[] VersionDeLaFila { get; set; } = null!;

        [ForeignKey("Articulo")]
        [InverseProperty("Items")]
        public virtual Articulo ArticuloNavigation { get; set; } = null!;
        [ForeignKey("Bodega")]
        [InverseProperty("Items")]
        public virtual Bodega BodegaNavigation { get; set; } = null!;
        [ForeignKey("Clasificacion")]
        [InverseProperty("Items")]
        public virtual Clasificacion ClasificacionNavigation { get; set; } = null!;
        [ForeignKey("Lote")]
        [InverseProperty("Items")]
        public virtual Lote LoteNavigation { get; set; } = null!;
        [ForeignKey("Ubicacion")]
        [InverseProperty("Items")]
        public virtual Ubicacion UbicacionNavigation { get; set; } = null!;
    }
}
