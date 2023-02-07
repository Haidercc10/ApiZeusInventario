using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models
{
    [Index("TipoDocumento", "ConsecutivoVariables", Name = "Consecutivovariable")]
    [Index("Referencia", Name = "DocumentoItemsReferencia")]
    [Index("Item", Name = "IX_DocumentoItems")]
    [Index("TipoDocumento", "Documento", Name = "IX_DocumentoItems_1")]
    [Index("Iden", Name = "IX_DocumentoItems_2")]
    [Index("IdDocumentoPosicionArancelaria", Name = "IX_DocumentoItems_3")]
    [Index("IdDocumentoImportacion", Name = "IX_DocumentoItems_4")]
    [Index("Documento", "TipoDocumento", "ItemsRelacionado", Name = "IX_DocumentoItems_Alfo20180910_Transito")]
    [Index("TipoDocumento", "Documento", "Referencia", Name = "IX_DocumentoItems_CGOMEZ_20210817")]
    [Index("TipoDocumento", "Documento", "ItemsRelacionado", Name = "IX_DocumentoItems_CGOMEZ_20210818")]
    [Index("TipoDocumento", "Documento", "OrdenGrabacion", Name = "IX_DocumentoItems_TipoDocumento_Documento_OrdenGrabacion")]
    [Index("TipoDocumento", "Documento", "Item", Name = "TipodocumentoDocumento")]
    [Index("ItemsRelacionado", Name = "itemsrelacionados")]
    [Index("OrdenGrabacion", Name = "ix_ordengrabacion")]
    public partial class DocumentoItem
    {
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Codigo { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? Aprobado { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal TipoDocumento { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Documento { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Item { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Cantidad { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal Faltantes { get; set; }
        public double ValorUnidad { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal PorcentajeDcto { get; set; }
        [Column("PorcentajeIVA", TypeName = "decimal(18, 6)")]
        public decimal PorcentajeIva { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal FletesUnidad { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DiasGarantia { get; set; }
        [Column("porcentajeimp", TypeName = "numeric(18, 6)")]
        public decimal Porcentajeimp { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal PrecioUnidad { get; set; }
        [Required]
        public bool? Descargardeinventarios { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal PrecioEnOtraMoneda { get; set; }
        [Column(TypeName = "text")]
        public string Seriales { get; set; } = null!;
        [Column(TypeName = "numeric(18, 2)")]
        public decimal CostoTotal { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal PrecioTotal { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal PrecioTotalEnOtraMoneda { get; set; }
        [Column("PorcentajeIVAMaxDeducible", TypeName = "numeric(18, 6)")]
        public decimal? PorcentajeIvamaxDeducible { get; set; }
        [Column("DETALLE")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Detalle { get; set; }
        [Column("TotalIVACompras", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvacompras { get; set; }
        [Column("TotalIVAVentas", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvaventas { get; set; }
        [Column("TotalIVAConsumo", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvaconsumo { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoCompra { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoVenta { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaGrabacion { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? OrdenGrabacion { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ItemsRelacionado { get; set; }
        public bool? CostoAjustado { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? TasaCambio { get; set; }
        public double? ValorUnidadOtraMoneda { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PorcentajeimpuestoOtraMoneda { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? OtrosCostosOtraMoneda { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CostoTotalOtraMoneda { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoCompraOtraMoneda { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoVentaOtraMoneda { get; set; }
        [Column("TotalIVAComprasOtraMoneda", TypeName = "numeric(18, 2)")]
        public decimal? TotalIvacomprasOtraMoneda { get; set; }
        [Column("TotalIVAVentasOtraMoneda", TypeName = "numeric(18, 2)")]
        public decimal? TotalIvaventasOtraMoneda { get; set; }
        [Column("ID_DocumentoPosicionArancelaria", TypeName = "numeric(18, 0)")]
        public decimal? IdDocumentoPosicionArancelaria { get; set; }
        [Column("ID_DocumentoImportacion", TypeName = "numeric(18, 0)")]
        public decimal? IdDocumentoImportacion { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? Empaques { get; set; }
        public bool? ArticuloIndirectoNoValorizaFormula { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PesoRealPorcionamiento { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioTotalReal { get; set; }
        public int? TiempoDeEntrega { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Referencia { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal CantidadPerdida { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ConsecutivoVariables { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PrecioxLote { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? TasaCalculo { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? ImpuestoConsumo { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorImpuestoConsumo { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorImpuestoConsumoOtraMoneda { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? IdProveedor { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioProveedor { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? RentabilidadProveedor { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PorcentajeIvaProvision { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? ImpoConPorcentaje { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? ImpoConPorcentajeMaximoDescontable { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConCompras { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConVentas { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConComprasOtraMoneda { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConVentasOtraMoneda { get; set; }
        [Column("TotalIVADescontable", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvadescontable { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConDescontable { get; set; }
        [Column("TasaNIIf")]
        public double TasaNiif { get; set; }
        public double ValorUnidad2 { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal CostoTotal2 { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? FletesUnidad2 { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PrecioUnidad2 { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? PrecioTotal2 { get; set; }
        [Column("TotalIVACompras2", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvacompras2 { get; set; }
        [Column("TotalIVAVentas2", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvaventas2 { get; set; }
        [Column("TotalIVAConsumo2", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvaconsumo2 { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoCompra2 { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoVenta2 { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorImpuestoConsumo2 { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConCompras2 { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConVentas2 { get; set; }
        [Column("TotalIVADescontable2", TypeName = "numeric(22, 6)")]
        public decimal? TotalIvadescontable2 { get; set; }
        [Column(TypeName = "numeric(22, 6)")]
        public decimal? TotalImpoConDescontable2 { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Iden { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoFinanciero { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDescuentoFinanciero2 { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? ContabilizaDescuentoFinanciero { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ImportacionFletes { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ImportacionSeguro { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ImportacionOtrosGastos { get; set; }
        [Column("Escenarios_TributarioConsumo_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosTributarioConsumoIden { get; set; }
        [Column("Escenarios_TributarioRenta_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosTributarioRentaIden { get; set; }
        [Column("Escenarios_SubCategoriaEfecCompra_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosSubCategoriaEfecCompraIden { get; set; }
        [Column("Escenarios_Escenario_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosEscenarioIden { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Ciudad { get; set; }
        public int? AutoGenerado { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Linea { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SubLinea { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaEntrega { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? DireccionEntrega { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? RubroPresu { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? ReservaPresu { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PorcentajeDctoConfidencial { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalDctoConfidencial { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        [Column("ValorUnidadINC", TypeName = "numeric(18, 6)")]
        public decimal? ValorUnidadInc { get; set; }
    }
}
