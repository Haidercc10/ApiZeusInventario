using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Ubicacion")]
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Existencia = new HashSet<Existencia>();
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string? UbicadoEn { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Bodega { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("Iden_ubicacion")]
        public int IdenUbicacion { get; set; }

        [InverseProperty("UbicacionNavigation")]
        public virtual ICollection<Existencia> Existencia { get; set; }
        [InverseProperty("UbicacionNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
