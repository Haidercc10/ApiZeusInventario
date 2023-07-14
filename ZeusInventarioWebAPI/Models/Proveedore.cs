using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models;

public partial class Proveedore
{
    [Key]
    [Column("IDPROVE")]
    [StringLength(25)]
    [Unicode(false)]
    public string Idprove { get; set; } = null!;

    [Column("IDTERCERO")]
    [StringLength(25)]
    [Unicode(false)]
    public string Idtercero { get; set; } = null!;

    [Column("RAZONCIAL")]
    [StringLength(250)]
    [Unicode(false)]
    public string Razoncial { get; set; } = null!;

    [Column("DIRECCION")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("CIUDAD")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Ciudad { get; set; }

    [Column("TELEFONO")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("FAX")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [Column("EMAIL")]
    [StringLength(800)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("WEBSITE")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Website { get; set; }

    [Column("IDZONA")]
    [StringLength(3)]
    [Unicode(false)]
    public string? Idzona { get; set; }

    [Column("DIPLAZO")]
    public short? Diplazo { get; set; }

    [Column("CUPOCRE", TypeName = "money")]
    public decimal? Cupocre { get; set; }

    [Column("CODICTA")]
    [StringLength(16)]
    [Unicode(false)]
    public string Codicta { get; set; } = null!;

    [Column("CONTACTO")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Contacto { get; set; }

    [Column("DIRCONTA")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Dirconta { get; set; }

    [Column("EMAILCONTA")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Emailconta { get; set; }

    [Column("TELCONTA")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Telconta { get; set; }

    [Column("CONTACTOA")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Contactoa { get; set; }

    [Column("DIRCONTAA")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Dircontaa { get; set; }

    [Column("EMAILCONTAA")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Emailcontaa { get; set; }

    [Column("TELCONTAA")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Telcontaa { get; set; }

    [Column("GERENTE")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Gerente { get; set; }

    [Column("DIRGERENTE")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Dirgerente { get; set; }

    [Column("EMAILGEREN")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Emailgeren { get; set; }

    [Column("TELGERENTE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Telgerente { get; set; }

    [Column("DIRCORRES")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Dircorres { get; set; }

    [Column("SEGMENTO")]
    [StringLength(16)]
    [Unicode(false)]
    public string? Segmento { get; set; }

    [Column("CODIGOUBICACION")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Codigoubicacion { get; set; }

    [Column("DIVPOLITICA")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Divpolitica { get; set; }

    [Column("CODIGODANE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Codigodane { get; set; }

    [Column("SERIE")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Serie { get; set; }

    [Column("AUTORIZACION")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Autorizacion { get; set; }

    [Column("CODALTERNO")]
    [StringLength(25)]
    [Unicode(false)]
    public string Codalterno { get; set; } = null!;

    [Column("INDEMAIL")]
    public byte Indemail { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Tag { get; set; } = null!;

    [Column("Prefijo_NCF")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PrefijoNcf { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? GrEmpresarial { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? CentroCosto { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Pais { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string? Item { get; set; }

    public byte? Bloqueo { get; set; }

    [Column("Bloq_Autorizacion")]
    public byte? BloqAutorizacion { get; set; }

    public int Deshabilitado { get; set; }

    public int? IdClaseProv { get; set; }

    public byte[] VersionDeLaFila { get; set; } = null!;

    [Column("Iden_proveedores")]
    public int IdenProveedores { get; set; }
}
