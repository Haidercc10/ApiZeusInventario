using System;
using System.Collections.Generic;

namespace ZeusInventarioWebAPI.Models
{
    public partial class Maevende
    {
        public string Idvende { get; set; } = null!;
        public string Nombvende { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        public string? Dircorres { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Idzona { get; set; }
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
        public decimal Pcomision { get; set; }
        public decimal Pdescuento { get; set; }
        public decimal MetaVenta { get; set; }
        public decimal Ppenalidad { get; set; }
        public int Deshabilitado { get; set; }
        public string Identificacion { get; set; } = null!;
        public byte[] VersionDeLaFila { get; set; } = null!;
        public int IdenMaevende { get; set; }
    }
}
