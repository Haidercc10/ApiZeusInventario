using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models;

[Keyless]
public partial class Tercero
{
    [Column("IDTERCERO")]
    [StringLength(25)]
    [Unicode(false)]
    public string Idtercero { get; set; } = null!;

    [Column("NOMBRETER")]
    [StringLength(250)]
    [Unicode(false)]
    public string Nombreter { get; set; } = null!;

    [Column("DIGIVERIF")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Digiverif { get; set; }

    [Column("TIPOTERCE")]
    [StringLength(2)]
    [Unicode(false)]
    public string? Tipoterce { get; set; }

    [Column("SEGMENTO")]
    [StringLength(16)]
    [Unicode(false)]
    public string? Segmento { get; set; }

    [Column("TIPOEMPRESA")]
    [StringLength(5)]
    [Unicode(false)]
    public string Tipoempresa { get; set; } = null!;

    [Column("DIRECCION")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("CIUDAD")]
    [StringLength(40)]
    [Unicode(false)]
    public string Ciudad { get; set; } = null!;

    [Column("DIVPOLITICA")]
    [StringLength(25)]
    [Unicode(false)]
    public string Divpolitica { get; set; } = null!;

    [Column("CODIGODANE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Codigodane { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? TipoIdentificacion { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Nombre1 { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Nombre2 { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Apellido1 { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Apellido2 { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? TipoRazonSocial { get; set; }

    [Column("Prefijo_NCF")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PrefijoNcf { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Sexo { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Profesion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaNacimiento { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Hobbies { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? NombreConyugue { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaNacimientoConyugue { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? TipoClienteFrecuenciaCompra { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? EstratoSocial { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Barrio { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Telefono2 { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Celular { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Fechagrabacion { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Pais { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string? CentroCosto { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? Item { get; set; }

    public int Deshabilitado { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string CodigoOcupacion { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int ManejaAcuerdo { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaInicialAcuerdo { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaFinalAcuerdo { get; set; }

    [Column("Escenarios_ClaseContribuyente_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosClaseContribuyenteIden { get; set; }

    [Column("Escenarios_CategoriaTributariaIVA_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosCategoriaTributariaIvaIden { get; set; }

    [Column("Escenarios_TipoContribuyente_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosTipoContribuyenteIden { get; set; }

    [Column("Escenarios_EsAutorretenedor_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosEsAutorretenedorIden { get; set; }

    [Column("Escenarios_AplicaICAT_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosAplicaIcatIden { get; set; }

    [Column("Escenarios_TipoRetencionIVA_Iden", TypeName = "numeric(18, 0)")]
    public decimal? EscenariosTipoRetencionIvaIden { get; set; }

    [Column("Escenarios_CategoriaTributaria")]
    [StringLength(25)]
    [Unicode(false)]
    public string? EscenariosCategoriaTributaria { get; set; }

    [Column("AReteSunat")]
    public bool AreteSunat { get; set; }

    [Column("APercepSunat")]
    public bool ApercepSunat { get; set; }

    public bool BuenContriSunat { get; set; }

    public byte[] VersionDeLaFila { get; set; } = null!;

    [Column("Iden_terceros")]
    public int IdenTerceros { get; set; }

    [Column("bl_CupoCreditoPorCliente")]
    public bool BlCupoCreditoPorCliente { get; set; }

    [Column("bl_CupoCreditoPorMoneda")]
    public bool BlCupoCreditoPorMoneda { get; set; }

    public int DiasGracia { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal ValorCupoCredito { get; set; }

    [Column("bl_Bloqueo")]
    public bool BlBloqueo { get; set; }

    public int DiPlazo { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string TipoBloqueo { get; set; } = null!;

    [Column("bl_FechaNacimiento")]
    public bool BlFechaNacimiento { get; set; }
}
