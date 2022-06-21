using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeusInventarioWebAPI.Models
{
    [Table("TipoDocumento")]
    [Index("Factor", Name = "IX_TipoDocumento_1")]
    [Index("Ciclo", Name = "IX_TipoDocumento_Ciclo")]
    public partial class TipoDocumento
    {
        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        public bool Listar { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Tabla { get; set; }
        [Column("factor", TypeName = "numeric(18, 0)")]
        public decimal Factor { get; set; }
        [Column("ciclo")]
        public int? Ciclo { get; set; }
        public bool? Usar { get; set; }
        public int? Orden { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Dependiente1 { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Dependiente2 { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Dependiente3 { get; set; }
        [StringLength(8000)]
        [Unicode(false)]
        public string? DescripcionDocument { get; set; }
        public bool? Aprobacion { get; set; }
        public bool? Disponibles { get; set; }
        public bool? Reproceso { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? DocumentoContable { get; set; }
        public bool Restringir { get; set; }
        public bool? ListarPuntoDeReorden { get; set; }
        public bool? PuntoDeReorden { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? AutoLiquidar { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Reporte { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal RelacionItemsConcepto { get; set; }
        [Column("AUXILIARVENTA")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Auxiliarventa { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaPuenteAjusteporRecosteo { get; set; }
        public int? ConfiguracionCuenta { get; set; }
        public short? ManejaConsecutivoManual { get; set; }
        public short? ExigeBodega { get; set; }
        public short? ExigeUbicacion { get; set; }
        public short? ExigeLote { get; set; }
        public short? ExigeClasificacion { get; set; }
        public short? ExigeSerie { get; set; }
        public short? ManejaDcto { get; set; }
        [Column("ManejaIVA")]
        public short? ManejaIva { get; set; }
        public short? ManejaOtrosCostos { get; set; }
        public short? ManejaImpuestoAlConsumo { get; set; }
        public short? ManejaMoneda { get; set; }
        public short? ManejaCostoOtraMoneda { get; set; }
        public short? ManejaPosicionArancelaria { get; set; }
        public short? AfectaExistenciaPosicionArancelaria { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal FactorDocumentoImportacion { get; set; }
        public int? MaximaPosicionesArancelarias { get; set; }
        [Column("FactorCR", TypeName = "numeric(18, 0)")]
        public decimal? FactorCr { get; set; }
        [Column("FactorDB", TypeName = "numeric(18, 0)")]
        public decimal? FactorDb { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? FactorIngresoRpt { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? FactorConceptoContable { get; set; }
        public bool? ControlDeInventario { get; set; }
        [Column("AuxiliarIVAVentas")]
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarIvaventas { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDevolucionVentas { get; set; }
        [Column("AuxiliarIVADevolucionVentas")]
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarIvadevolucionVentas { get; set; }
        [Column("Aprobacion_Monto")]
        public bool? AprobacionMonto { get; set; }
        public bool? UtilizaSolicitante { get; set; }
        public bool? Liquidable { get; set; }
        public bool? LiquidableDependiente1 { get; set; }
        public bool? LiquidableDependiente2 { get; set; }
        public bool? LiquidableDependiente3 { get; set; }
        public bool? HistorialDetalles { get; set; }
        public bool? Preaprobacion { get; set; }
        [Column("CantidadesSuperioresImportadas_Tipo")]
        [StringLength(1)]
        [Unicode(false)]
        public string? CantidadesSuperioresImportadasTipo { get; set; }
        [Column("validarFecha")]
        public bool? ValidarFecha { get; set; }
        public bool? AprobMonArtCon { get; set; }
        public bool? RestringirPorMuntoUsuario { get; set; }
        public int? FactorDisponibilidad { get; set; }
        public bool? LiquidacionAutomaticaCierre { get; set; }
        public bool? FirmaDigital { get; set; }
        [Column("Monto_General", TypeName = "numeric(18, 2)")]
        public decimal? MontoGeneral { get; set; }
        [Column("Monto_Articulos", TypeName = "numeric(18, 2)")]
        public decimal? MontoArticulos { get; set; }
        [Column("Monto_Conceptos", TypeName = "numeric(18, 2)")]
        public decimal? MontoConceptos { get; set; }
        public bool? ImpresionDirecta { get; set; }
        public bool? ValidarVariableDescuento { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? NombreVariableDescuento { get; set; }
        public bool? NesecitaAprobacionVariableDescuento { get; set; }
        public bool? ImpresorasFiscal { get; set; }
        [StringLength(3)]
        [Unicode(false)]
        public string? PrefijoReferencia { get; set; }
        public bool? HabilitarSeguimientoPorReferencias { get; set; }
        public bool? NoPermitirRevertir { get; set; }
        public bool? ManejaOrdenDespacho { get; set; }
        public bool? ControlDeProcesos { get; set; }
        [Column("bitModificacionVariablesAdicionales")]
        public bool? BitModificacionVariablesAdicionales { get; set; }
        [Column("bitValidarItemDuplicado")]
        public bool? BitValidarItemDuplicado { get; set; }
        public bool? ExistenciaSinLote { get; set; }
        [Column("bitProgramacion")]
        public bool? BitProgramacion { get; set; }
        public bool? ManejaEstadoConfirmacion { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string? ImprimirMediaCarta { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? AuxiliarDescuentoVenta { get; set; }
        [Column("ZeusMR")]
        [StringLength(256)]
        [Unicode(false)]
        public string? ZeusMr { get; set; }
        public bool? NoPermiteMezclaTipoArticulo { get; set; }
        public bool? SugiereBodegaElaboracion { get; set; }
        public bool? ValidaBodegaElaboracion { get; set; }
        public bool? ExigirReferencia { get; set; }
        [Column("ActiveMQ")]
        public bool? ActiveMq { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? FactorSoporte { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        public bool? Verificacion { get; set; }
        [Column("BFechaCorte")]
        public bool? BfechaCorte { get; set; }
        public bool? Alfabeticamente { get; set; }
        public bool? MostrarGuiaRemision { get; set; }
        public bool? ExigirGuiaRemision { get; set; }
        public bool? RegenerarXmlInsertar { get; set; }
        public bool? PuntoReordenAutomatico { get; set; }
    }
}
