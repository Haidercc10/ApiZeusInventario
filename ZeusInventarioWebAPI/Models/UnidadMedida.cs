using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            UnidadMedidaArticulos = new HashSet<UnidadMedidaArticulo>();
        }

        [Column("IDEN", TypeName = "numeric(18, 0)")]
        public decimal Iden { get; set; }
        [Key]
        [StringLength(150)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(4000)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        public int? Tipo { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;

        public virtual ICollection<UnidadMedidaArticulo> UnidadMedidaArticulos { get; set; }
    }
}
