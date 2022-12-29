using System;
using System.Collections.Generic;

namespace ZeusInventarioWebAPI;

public partial class Cliente
{
    public string Idcliente { get; set; } = null!;

    public string Idtercero { get; set; } = null!;

    public string Razoncial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public string? Fax { get; set; }

    public string? Dircorres { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string Idzona { get; set; } = null!;

    public string Idvende { get; set; } = null!;

    public short? Diplazo { get; set; }

    public decimal? Cupocre { get; set; }

    public string Codicta { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Dirconta { get; set; }

    public string? Emailconta { get; set; }

    public string? Telconta { get; set; }

    public string? Contactoa { get; set; }

    public string? Dircontaa { get; set; }

    public string? Emailcontaa { get; set; }

    public string? Telcontaa { get; set; }

    public string? Gerente { get; set; }

    public string? Emailgeren { get; set; }

    public string? Dirgerente { get; set; }

    public string? Telgerente { get; set; }

    public string TipoCliente { get; set; } = null!;

    public short? Diagracia { get; set; }

    public bool? Bloqueo { get; set; }

    public bool? Autorizacion { get; set; }

    public bool? Bloqueopornit { get; set; }

    public string? Segmento { get; set; }

    public string? Tag { get; set; }

    public string? Codigoubicacion { get; set; }

    public string? FormatoDeFactura { get; set; }

    public string? FormatoDePedido { get; set; }

    public string? FormatoDeRemision { get; set; }

    public string? FormatoDeFacturaRemision { get; set; }

    public string? Divpolitica { get; set; }

    public string? Codigodane { get; set; }

    public string? CodAlterno { get; set; }

    public byte? IndNcf { get; set; }

    public string? GrEmpresarial { get; set; }

    public string? Pais { get; set; }

    public string Tipo { get; set; } = null!;

    public string? CentroCosto { get; set; }

    public string? Item { get; set; }

    public int GenerarMora { get; set; }

    public decimal IntMora { get; set; }

    public int Deshabilitado { get; set; }

    public int? Fpagcontado { get; set; }

    public int? Fpagcredito { get; set; }

    public byte[] VersionDeLaFila { get; set; } = null!;

    public int IdenClientes { get; set; }

    public string? TipoNotificacionFe { get; set; }

    public string? ProveedorTecnologico { get; set; }

    public string? UsoLibre { get; set; }

    public bool BlCupoCreditoPorMoneda { get; set; }

    public int TipoAsumeMora { get; set; }
}
