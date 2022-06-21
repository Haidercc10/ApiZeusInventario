using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    public partial class ModalidadesVenta
    {
        public ModalidadesVenta()
        {
            FacturaDeClientes = new HashSet<FacturaDeCliente>();
        }

        [Key]
        [StringLength(5)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("Iden_modalidadesventas")]
        public int IdenModalidadesventas { get; set; }

        [InverseProperty("ModalidadVentasNavigation")]
        public virtual ICollection<FacturaDeCliente> FacturaDeClientes { get; set; }
    }
}
