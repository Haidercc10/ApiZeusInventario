using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("UnidadMedida_Articulo")]
    public partial class UnidadMedidaArticulo
    {
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Articulo { get; set; }
        [Key]
        [Column("IDEN_Unidad", TypeName = "numeric(18, 0)")]
        public decimal IdenUnidad { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Factor { get; set; }
        [Column("Iden_unidadmedida_articulo")]
        public int IdenUnidadmedidaArticulo { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;

        [ForeignKey("Articulo")]
        [InverseProperty("UnidadMedidaArticulos")]
        public virtual Articulo ArticuloNavigation { get; set; } = null!;
        public virtual UnidadMedida IdenUnidadNavigation { get; set; } = null!;
    }
}
