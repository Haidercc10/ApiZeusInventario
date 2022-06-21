using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Clasificacion")]
    [Index("Codigo", "Mee", Name = "IX_Clasificacion_1")]
    [Index("TipoClasificacion", Name = "IX_Clasificacion_2")]
    [Index("CodigoRelacion", Name = "IX_Clasificacion_CodigoRelacion")]
    [Index("DocumentoExternoTipo", "DocumentoExternoDocumento", Name = "IX_Clasificacion_DocumentoExterno_Tipo_Documento")]
    [Index("NoDisponibilidadMotivo", Name = "IX_Clasificacion_NoDisponibilidad_Motivo")]
    [Index("NoDisponibilidadResponsable", Name = "IX_Clasificacion_NoDisponibilidad_Responsable")]
    [Index("Proveedor", Name = "IX_Clasificacion_Proveedor")]
    [Index("ReservaCliente", Name = "IX_Clasificacion_Reserva_Cliente")]
    [Index("ReservaMotivo", Name = "IX_Clasificacion_Reserva_Motivo")]
    [Index("ReservaSolicitante", Name = "IX_Clasificacion_Reserva_Solicitante")]
    public partial class Clasificacion
    {
        public Clasificacion()
        {
            Existencia = new HashSet<Existencia>();
            Items = new HashSet<Item>();
        }

        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Codigo { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(1000)]
        [Unicode(false)]
        public string? Descripcion { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Cuenta { get; set; }
        [Column("MEE")]
        public bool? Mee { get; set; }
        [Column("MUE")]
        public bool? Mue { get; set; }
        [Column("MD")]
        public bool? Md { get; set; }
        [Column("MRT")]
        public bool? Mrt { get; set; }
        [Column("tipoClasificacion")]
        public int? TipoClasificacion { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Proveedor { get; set; }
        [Column("NoDisponibilidad_Responsable", TypeName = "numeric(18, 0)")]
        public decimal? NoDisponibilidadResponsable { get; set; }
        [Column("NoDisponibilidad_Motivo", TypeName = "numeric(18, 0)")]
        public decimal? NoDisponibilidadMotivo { get; set; }
        [Column("NoDisponibilidad_Observaciones")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? NoDisponibilidadObservaciones { get; set; }
        [Column("Reserva_Solicitante", TypeName = "numeric(18, 0)")]
        public decimal? ReservaSolicitante { get; set; }
        [Column("Reserva_Cliente")]
        [StringLength(25)]
        [Unicode(false)]
        public string? ReservaCliente { get; set; }
        [Column("Reserva_Motivo", TypeName = "numeric(18, 0)")]
        public decimal? ReservaMotivo { get; set; }
        [Column("Reserva_Observaciones")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? ReservaObservaciones { get; set; }
        [Column("Reserva_Fecha", TypeName = "smalldatetime")]
        public DateTime? ReservaFecha { get; set; }
        [Column("Reserva_Vencimiento", TypeName = "smalldatetime")]
        public DateTime? ReservaVencimiento { get; set; }
        [Column("DocumentoExterno_Tipo")]
        [StringLength(25)]
        [Unicode(false)]
        public string? DocumentoExternoTipo { get; set; }
        [Column("DocumentoExterno_Documento")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DocumentoExternoDocumento { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? OtrosDatos1 { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? OtrosDatos2 { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? OtrosDatos3 { get; set; }
        [Column("Reserva_ControlFecha")]
        public bool? ReservaControlFecha { get; set; }
        public bool? Deshabilitada { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? CodigoRelacion { get; set; }
        public bool? EsPropiedadPlantaEquipo { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Referencia { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("Iden_clasificacion")]
        public int IdenClasificacion { get; set; }

        [InverseProperty("ClasificacionNavigation")]
        public virtual ICollection<Existencia> Existencia { get; set; }
        [InverseProperty("ClasificacionNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
