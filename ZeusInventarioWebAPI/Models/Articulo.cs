using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace ZeusInventarioWebAPI.Models
{
    [Table("Articulo")]
    [Index("Grupo", Name = "Grupo")]
    [Index("Presentacion", "Codigo", Name = "IX_Articulo", IsUnique = true)]
    [Index("GrupoAuxiliar", Name = "IX_Articulo_1")]
    [Index("Codigo", Name = "IX_Articulo_2")]
    [Index("DesHabilitado", Name = "IX_Articulo_3")]
    [Index("ClasificacionPorDefecto", Name = "IX_Articulo_ClasificacionDefecto")]
    [Index("CodigoFacturacion", Name = "IX_Articulo_CodigoFacturacion")]
    [Index("Tipo", Name = "IX_Articulo_Tipo")]
    [Index("TipoArticulo", Name = "IX_Articulo_TipoArticulo")]
    [Index("ConfiguracionPrecioVenta", Name = "IX_ConfiguracionPrecioVenta")]
    [Index("Formula", Name = "IX_FORMULA")]
    [Index("NoIncluirEnMontoParaAprobacion", Name = "IX_NoIncluirEnMontoParaAprobacion")]
    [Index("PosicionArancelaria", Name = "IX_PosicionArancelaria")]
    [Index("Atc", Name = "I_Articulo_20210127")]
    [Index("Codigo", "CodigoBarra", Name = "Ix_Codigobarras")]
    [Index("Nombre", Name = "Nombre")]
    public partial class Articulo
    {
        public Articulo()
        {
            Existencia = new HashSet<Existencia>();
            Items = new HashSet<Item>();
            UnidadMedidaArticulos = new HashSet<UnidadMedidaArticulo>();
        }

        [Key]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal IdArticulo { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Codigo { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? Descripcion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Grupo { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string? Tipo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Valorización { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Presentacion { get; set; }
        public bool? DesHabilitado { get; set; }
        public int Prioridad { get; set; }
        public int? DiasGarantia { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Peso { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Pesoconempaque { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? DetallesTecnicos { get; set; }
        public bool? ExigirCentroCosto { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CuentaInventario { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CuentaCosto { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CuentaVenta { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? GrupoAuxiliar { get; set; }
        public byte? ComplementoCosto { get; set; }
        public byte? ComplementoVenta { get; set; }
        public byte? ComplementoInventario { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? ImpuestoConsumo { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? Centrocosto { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Categoria { get; set; }
        public int? TiempoReposicion { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? PorcentajeIva { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? PuntoDeReorden { get; set; }
        public int? Minimo { get; set; }
        public int? Maximo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PosicionArancelaria { get; set; }
        [Column("FOBDolares", TypeName = "decimal(18, 4)")]
        public decimal? Fobdolares { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PorcentajeGravamen { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? PorcentajeRentabilidad { get; set; }
        public bool? ExigeSerie { get; set; }
        [Column(TypeName = "image")]
        public byte[]? Foto { get; set; }
        public bool Lote { get; set; }
        [Column("FOBEuro", TypeName = "decimal(18, 0)")]
        public decimal? Fobeuro { get; set; }
        [Column("CIFDolares", TypeName = "decimal(18, 0)")]
        public decimal? Cifdolares { get; set; }
        [Column("CIFEuro", TypeName = "decimal(18, 0)")]
        public decimal? Cifeuro { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Formula { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal PrecioVenta { get; set; }
        public int ConfiguracionPrecioVenta { get; set; }
        [Column("cuentaiva")]
        [StringLength(30)]
        [Unicode(false)]
        public string? Cuentaiva { get; set; }
        [Column("complementoiva")]
        public byte? Complementoiva { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? DemandaPromedio { get; set; }
        [Column("diasdeinventario")]
        public int? Diasdeinventario { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? Porcentajecomision { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? UnidadPorEmpaque { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaGastoProvision { get; set; }
        [Column("CuentaIVAVentas")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CuentaIvaventas { get; set; }
        [Column("ComplementoIVAVentas")]
        public byte? ComplementoIvaventas { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaInventarioxEntregar { get; set; }
        public byte? ComplementoInventarioxEntregar { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaInventarioRemisionado { get; set; }
        public byte? ComplementoInventarioRemisionado { get; set; }
        public byte? ComplementoCentroCosto { get; set; }
        public bool Perecedero { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? LineaProduccion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CuentaajusteInflacion { get; set; }
        public byte? ComplementoAjusteInflacion { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? DescripcionOtroIdioma { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Frecuenciadecompra { get; set; }
        public byte? ComplementoVenta1 { get; set; }
        public byte? ComplementoVenta2 { get; set; }
        public byte? ComplementoVenta3 { get; set; }
        public byte? ComplementoCosto1 { get; set; }
        public byte? ComplementoCosto2 { get; set; }
        public byte? ComplementoCosto3 { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string? TipoArticulo { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Fabricante { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CodigoBarra { get; set; }
        public bool? ManejaProgramaEspecial { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? MensajeProgramaEspecial { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PresentacionPorEmpaque { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? UnidadesContenidaEmpaque { get; set; }
        public bool? ExigirInformacionUsuarioVenta { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? FactorDeSeguridad { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? PorcentajeDescuento { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CodigoFacturacion { get; set; }
        [Column("CuentaIVAConsumo")]
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaIvaconsumo { get; set; }
        [Column("ComplementoIVAConsumo")]
        public byte? ComplementoIvaconsumo { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? GrupoFacturacion { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? Volumen { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? GradosContenidos { get; set; }
        public bool? NoAplicarAjusteInflacion { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? UnidadesporEtiquetas { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? PartidaAjusteInflacion { get; set; }
        public byte? ComplementoPartidaAjusteInflacion { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? DemandaPromedioPedidosNormales { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? DemandaPromedioPedidosOcasionales { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? DemandaPromedioPedidosProgramados { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? OrdenesPendientes { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PedidosPendientes { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasMaximodeInventarios { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasMinimosdeInventarios { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CantidadSugeridaCompra { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CantidadSugeridaNacionalizacion { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CantidadSugeridaCompraEmp { get; set; }
        public int? TipoReporteEnVentas { get; set; }
        [Column("ConceptoVariacionReporteEnVEntas")]
        [StringLength(30)]
        [Unicode(false)]
        public string? ConceptoVariacionReporteEnVentas { get; set; }
        [Column("CuentaIVADevolucionVentas")]
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaIvadevolucionVentas { get; set; }
        [Column("ComplementoIVADevolucionVentas")]
        public byte? ComplementoIvadevolucionVentas { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaDevolucionVentas { get; set; }
        public byte? ComplementoDevolucionVentas1 { get; set; }
        public byte? ComplementoDevolucionVentas2 { get; set; }
        public byte? ComplementoDevolucionVentas3 { get; set; }
        public byte? ComplementoDevolucionVentas4 { get; set; }
        public bool? PermitirCantidadessinCosto { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? CodigoFacturacion2 { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? GrupoFacturacion2 { get; set; }
        [Column("IDEN_EsquemasFormula", TypeName = "numeric(18, 0)")]
        public decimal? IdenEsquemasFormula { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string? CodSustentosTributario { get; set; }
        public bool? ProductoRefrigerado { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TempMinRefrigeracion { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TempMaxRefrigeracion { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasMinimoVencimiento { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? ArticuloBolsaAgropecuaria { get; set; }
        public bool? NoIncluirEnMontoParaAprobacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? BodegaElaboracion { get; set; }
        public bool? Monitor { get; set; }
        public bool? ParaDispositivoMovil { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? BodegaCompra { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? UbicacionBodegaCompra { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? UbicacionBodegaElaboracion { get; set; }
        [Column("MaximoIVADescontable", TypeName = "numeric(18, 4)")]
        public decimal? MaximoIvadescontable { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? ImpoConPorcentaje { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? ImpoConPorcentajeMaximoDescontable { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ImpoConCompraCuenta { get; set; }
        public byte? ImpoConCompraComplemento { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ImpoConCompraDevolucionCuenta { get; set; }
        public byte? ImpoConCompraDevolucionComplemento { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ImpoConVentaCuenta { get; set; }
        public byte? ImpoConVentaComplemento { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? ImpoConVentaDevolucionCuenta { get; set; }
        public byte? ImpoConVentaDevolucionComplemento { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? DiasAlertaPorVencimiento { get; set; }
        public bool? ModificarCantidadAlistamientoPorVerificacion { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ClasificacionPorDefecto { get; set; }
        [Column("vchPrincipioActivo")]
        [StringLength(250)]
        [Unicode(false)]
        public string? VchPrincipioActivo { get; set; }
        [Column("vchNivelRiesgo")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VchNivelRiesgo { get; set; }
        [Column("vchCantidadConcentrada")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VchCantidadConcentrada { get; set; }
        [Column("bitRecetable")]
        public bool? BitRecetable { get; set; }
        [Column("bitSolucion")]
        public bool? BitSolucion { get; set; }
        [Column("bitInsulina")]
        public bool? BitInsulina { get; set; }
        [Column("vchTipoMedicamento")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VchTipoMedicamento { get; set; }
        [Column("vchCUM")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VchCum { get; set; }
        [Column("vchINVIMA")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VchInvima { get; set; }
        public double? PrecioComercial { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad1 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad2 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad3 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad4 { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? Propiedad5 { get; set; }
        public byte? ComplementoPropiedad1 { get; set; }
        public byte? ComplementoPropiedad2 { get; set; }
        public byte? ComplementoPropiedad3 { get; set; }
        public byte? ComplementoPropiedad4 { get; set; }
        public byte? ComplementoPropiedad5 { get; set; }
        public double? PrecioComercial2 { get; set; }
        public bool? EsAjustadoPorDeterioro { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaIngresoDescFinancieroEnCompras { get; set; }
        public byte? ComplementoIngresoDescFinancieroEnCompras { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaGastoDescFinancieroEnVenta { get; set; }
        public byte? ComplementoGastoDescFinancieroEnVenta { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? DevolucionPorGarantia { get; set; }
        public byte? ComplementoDevolucionPorGarantia { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? ProvisionGarantia { get; set; }
        public byte? ComplementoProvisionGarantia { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? PorcentajeProvisionGarantia { get; set; }
        [Column("numCategoriaConteoCiclicoId", TypeName = "numeric(18, 0)")]
        public decimal? NumCategoriaConteoCiclicoId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? CuentaDescuentoVenta { get; set; }
        public byte? ComplementoDescuentoVenta { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? CostoArticulo { get; set; }
        public int? DiasAvisoVencimiento { get; set; }
        [Column("Escenarios_TributarioConsumo_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosTributarioConsumoIden { get; set; }
        [Column("Escenarios_TributarioRenta_Iden", TypeName = "numeric(18, 0)")]
        public decimal? EscenariosTributarioRentaIden { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? CuentaRemisionReconocimientoIngreso { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ComplementoRemisionReconocimientoIngreso { get; set; }
        [StringLength(8000)]
        [Unicode(false)]
        public string? FotoNombre { get; set; }
        [Column("FCreacion", TypeName = "smalldatetime")]
        public DateTime? Fcreacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Componente { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? BienesServiciosCodigo { get; set; }
        public bool? NoModificarTrasfAuto { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaUltimaModificacion { get; set; }
        public bool? ManejaBascula { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? PlantillaPorcionamientoIden { get; set; }
        public bool? Activo { get; set; }
        public bool? ProductoSolicitudPorcionamiento { get; set; }
        public bool? ControlVariacionCostoEstandar { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? ControlVariacionCostoEstandarPorcentaje { get; set; }
        [Column("ArticuloAPorcionar", TypeName = "numeric(18, 0)")]
        public decimal? ArticuloAporcionar { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Merma { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? PorcentajeMerma { get; set; }
        public bool? ControlUnidadesContenidaEmpaque { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? TipoControlUnidadesContenidaEmpaque { get; set; }
        public byte[] VersionDeLaFila { get; set; } = null!;
        public bool? NoAfectarInventario { get; set; }
        public bool? ExigirReferenciaEnDocumentos { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ProduccionOrdenamiento { get; set; }
        public bool? LoteFormulado { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string? TipoPresentacion { get; set; }
        public bool? AgregarTransito { get; set; }
        [Column(TypeName = "numeric(18, 6)")]
        public decimal? Calorias { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? VencimientoInvima { get; set; }
        [Column("IUMPrimerNivel")]
        [StringLength(50)]
        [Unicode(false)]
        public string? IumprimerNivel { get; set; }
        [Column("IUMSegundoNivel", TypeName = "numeric(18, 0)")]
        public decimal? IumsegundoNivel { get; set; }
        [Column("IUMTercerNivel", TypeName = "numeric(18, 0)")]
        public decimal? IumtercerNivel { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? NumeroExpediente { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ConsecutivoComercial { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? UnidadFactura { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ViaAdministrasion { get; set; }
        public bool? MedicamenteDiluido { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FormaFarmaceutica { get; set; }
        public bool? AplicaDiaSinIva { get; set; }
        [Column("ChkValorINC")]
        public bool? ChkValorInc { get; set; }
        [Column("ValorINC", TypeName = "numeric(18, 6)")]
        public decimal? ValorInc { get; set; }
        public bool? BloqueoRangoFecha { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? BloqueoFechaInicial { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? BloqueoFechaFinal { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? MotivoBloqueoRangoFecha { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaDeBloqueoRangoFecha { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? UsuarioDeBloqueoRangoFecha { get; set; }
        [Column("ATC")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Atc { get; set; }

        [ForeignKey("Grupo")]
        [InverseProperty("Articulos")]
        public virtual Grupo GrupoNavigation { get; set; } = null!;
        [InverseProperty("ArticuloNavigation")]
        public virtual ICollection<Existencia> Existencia { get; set; }
        [InverseProperty("ArticuloNavigation")]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty("ArticuloNavigation")]
        public virtual ICollection<UnidadMedidaArticulo> UnidadMedidaArticulos { get; set; }
    }
}
