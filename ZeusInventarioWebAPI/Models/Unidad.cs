using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Keyless]
    [Table("Unidad")]
    public partial class Unidad
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        [Column("Iden_unidad")]
        public int IdenUnidad { get; set; }
    }
}
