using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models;

[Keyless]
[Table("Remision")]
[Index("Cliente", Name = "Cliente")]
[Index("DocumentoRev", Name = "DocumentoRev")]
[Index("RemisionPadre", Name = "IX_RemisionPadre")]
[Index("Moneda", Name = "Moneda")]
[Index("Usuario", Name = "Usuario")]
[Index("Vendedor", Name = "Vendedor")]
[Index("Fecha", Name = "fecha")]
public partial class Remision
{
    [Column(TypeName = "numeric(18, 0)")]
    public decimal Consecutivo { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string? Cliente { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Vendedor { get; set; } = null!;

    [StringLength(2000)]
    [Unicode(false)]
    public string? Detalle { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Moneda { get; set; } = null!;

    [Column(TypeName = "numeric(18, 6)")]
    public decimal Tasacambio { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Usuario { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? DocumentoRev { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? Fuente { get; set; }

    [Column("serie")]
    [StringLength(2)]
    [Unicode(false)]
    public string? Serie { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Documento { get; set; }

    public bool? Facturada { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ListaDePrecios { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DespachoCliente { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DespachoDireccion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DespachoCiudad { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DespachoTransportadora { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ObservacionInterna { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? ModalidadVentas { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EntregadeFactura { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? IdenRuta { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Transportador { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Placa { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? DirPartida { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaIniTransporte { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaFinTransporte { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? DocAduanero { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CodEstDestino { get; set; }

    [Column("NCF")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Ncf { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCaducidad { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? CentroCosto { get; set; }

    public bool? EsClienteSecundario { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? RemisionPadre { get; set; }

    public bool? Dividida { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? DivisionRemision { get; set; }

    public bool? DevolucionVentas { get; set; }

    [Column("Iden_remision")]
    public int IdenRemision { get; set; }
}
