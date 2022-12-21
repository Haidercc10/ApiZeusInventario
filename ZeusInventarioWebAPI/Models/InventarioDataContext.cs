using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZeusInventarioWebAPI.Models
{
    public partial class InventarioDataContext : DbContext
    {
        public InventarioDataContext()
        {
        }

        public InventarioDataContext(DbContextOptions<InventarioDataContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<MovimientoItem> MovimientoItems { get; set; } = null!;
        //public virtual DbSet<Transac> Transacs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("server=192.168.0.85; database= Inventario; User ID= Admin; pwd= 102024");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<MovimientoItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MovimientoItems");

                entity.Property(e => e.Aplicacion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Aprobado).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Aprueba).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Auxiliar)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BU");

                entity.Property(e => e.Caja)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Cajero).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CantidadPerdida).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Cargo1).HasColumnType("money");

                entity.Property(e => e.Cargo2).HasColumnType("money");

                entity.Property(e => e.Cargo3).HasColumnType("money");

                entity.Property(e => e.CentroCosto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoBodega)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoClasificacion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoDocuItem).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoDocumento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoItem).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoReferencia)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoDocumento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoUbicacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("consecutivo");

                entity.Property(e => e.ConsecutivoBu)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ConsecutivoBU");

                entity.Property(e => e.ConsecutivoExterno).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ConsecutivoVariables).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContabilizaDescuentoFinanciero)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CostoTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CostoTotal2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CostoTotalOtraMoneda).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CuentaAnticipo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DespachoCiudad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DespachoCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DespachoDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DespachoTransportadora)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DetalleDocumento)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DiasGarantia).HasColumnType("smalldatetime");

                entity.Property(e => e.Diascreditos)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DIASCREDITOS");

                entity.Property(e => e.DireccionEntrega)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoConPendiente).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DocumentoTercero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EscenariosEscenarioIden)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Escenarios_Escenario_Iden");

                entity.Property(e => e.EscenariosSubCategoriaEfecCompraIden)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Escenarios_SubCategoriaEfecCompra_Iden");

                entity.Property(e => e.EscenariosTributarioConsumoIden)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Escenarios_TributarioConsumo_Iden");

                entity.Property(e => e.EscenariosTributarioRentaIden)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Escenarios_TributarioRenta_Iden");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoExterno)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Factor).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Faltantes).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FechaDocumento).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaEntrega).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaRequerida).HasColumnType("smalldatetime");

                entity.Property(e => e.Fechafactura)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fechafactura");

                entity.Property(e => e.FletesUnidad).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FletesUnidad2).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fuente)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdArticulo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdProveedor)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ImpoConPorcentaje).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ImpoConPorcentajeMaximoDescontable).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ItemsRelacionado).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Jornada)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Linea)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModalidadVentas)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ncf)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ncf");

                entity.Property(e => e.NcfModificado)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ncf_Modificado");

                entity.Property(e => e.NombreArticulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreBodega)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCaja)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCajero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreClasificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDepartamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreGrupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreJornada)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreLote)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePrestadorServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreReferencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolicitante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTercero)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUbicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuarioServicio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreVendedor)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Numerocuotas)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("NUMEROCUOTAS");

                entity.Property(e => e.Ordengrabacion)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ordengrabacion");

                entity.Property(e => e.OtrosCostosOtraMoneda).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PesoRealPorcionamiento).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PorcentajeDcto).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PorcentajeDctoConfidencial).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PorcentajeIva)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PorcentajeIVA");

                entity.Property(e => e.PorcentajeIvaProvision).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PorcentajeIvamaxDeducible)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PorcentajeIVAMaxDeducible");

                entity.Property(e => e.Porcentajeimp)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("porcentajeimp");

                entity.Property(e => e.PorcentajeimpuestoOtraMoneda).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PrecioEnOtraMoneda).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PrecioProveedor).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioTotal2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioTotalEnOtraMoneda).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioTotalReal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioUnidad).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PrecioUnidad2).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PrecioxLote).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Presentacion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PrestadorServicio)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RentabilidadProveedor).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ReservaPresu)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RubroPresu)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Serial).HasColumnType("text");

                entity.Property(e => e.Serie)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Solicitante).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SubLinea)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TasaCalculo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TasaCambio).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TasaCambioItems).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TasaNiif).HasColumnName("TasaNIIf");

                entity.Property(e => e.Tercero)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoDocumentoExterno).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoFactura)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoRemision)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDctoConfidencial).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoCompra).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoCompra2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoCompraOtraMoneda).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoFinanciero).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoFinanciero2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoVenta).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoVenta2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDescuentoVentaOtraMoneda).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalImpoConCompras).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConCompras2).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConComprasOtraMoneda).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConDescontable).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConDescontable2).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConVentas).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConVentas2).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalImpoConVentasOtraMoneda).HasColumnType("numeric(22, 6)");

                entity.Property(e => e.TotalIvacompras)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVACompras");

                entity.Property(e => e.TotalIvacompras2)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVACompras2");

                entity.Property(e => e.TotalIvacomprasOtraMoneda)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("TotalIVAComprasOtraMoneda");

                entity.Property(e => e.TotalIvaconsumo)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVAConsumo");

                entity.Property(e => e.TotalIvaconsumo2)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVAConsumo2");

                entity.Property(e => e.TotalIvadescontable)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVADescontable");

                entity.Property(e => e.TotalIvadescontable2)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVADescontable2");

                entity.Property(e => e.TotalIvaventas)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVAVentas");

                entity.Property(e => e.TotalIvaventas2)
                    .HasColumnType("numeric(22, 6)")
                    .HasColumnName("TotalIVAVentas2");

                entity.Property(e => e.TotalIvaventasOtraMoneda)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("TotalIVAVentasOtraMoneda");

                entity.Property(e => e.Usuario).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuarioServicio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorAnticipo).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValorImpuestoConsumo2).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValorUnidadInc)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("ValorUnidadINC");

                entity.Property(e => e.Vencimientoinicial)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("VENCIMIENTOINICIAL");

                entity.Property(e => e.Vendedor)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transac>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TRANSAC");

                entity.Property(e => e.Adicional1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adicional_1");

                entity.Property(e => e.Adicional2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adicional_2");

                entity.Property(e => e.Anotra)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ANOTRA");

                entity.Property(e => e.Autorizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AUTORIZACION");

                entity.Property(e => e.Auxiaux)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("AUXIAUX")
                    .IsFixedLength();

                entity.Property(e => e.BaseComision).HasColumnType("money");

                entity.Property(e => e.Baseretetra)
                    .HasColumnType("money")
                    .HasColumnName("BASERETETRA");

                entity.Property(e => e.Bu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BU");

                entity.Property(e => e.Cliprv)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CLIPRV");

                entity.Property(e => e.Codicta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CODICTA")
                    .IsFixedLength();

                entity.Property(e => e.CodigoPropiedad1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPropiedad2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPropiedad3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPropiedad4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPropiedad5)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Codpresu)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CODPRESU")
                    .IsFixedLength();

                entity.Property(e => e.Conciltra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CONCILTRA")
                    .IsFixedLength();

                entity.Property(e => e.Consecurev).HasColumnName("CONSECUREV");

                entity.Property(e => e.Consecutra)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONSECUTRA");

                entity.Property(e => e.Descritra)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRITRA");

                entity.Property(e => e.FactMovimientoOriginal).HasColumnName("fact_movimiento_original");

                entity.Property(e => e.FechaCaducidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fechafact)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FECHAFACT")
                    .IsFixedLength();

                entity.Property(e => e.Fechatra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FECHATRA")
                    .IsFixedLength();

                entity.Property(e => e.Fgratra)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("FGRATRA");

                entity.Property(e => e.GenEsquemaTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdAplicacionesOrigen).HasColumnName("Id_AplicacionesOrigen");

                entity.Property(e => e.IdAplicacionesZeus).HasColumnName("Id_AplicacionesZeus");

                entity.Property(e => e.IdMovimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Id_Movimiento");

                entity.Property(e => e.IdOrigenMovimiento).HasColumnName("Id_OrigenMovimiento");

                entity.Property(e => e.Idbanco)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IDBANCO")
                    .IsFixedLength();

                entity.Property(e => e.Idcenco)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("IDCENCO")
                    .IsFixedLength();

                entity.Property(e => e.IdenEsquemaTransaccion)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Iden_EsquemaTransaccion");

                entity.Property(e => e.Idfuente)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDFUENTE")
                    .IsFixedLength();

                entity.Property(e => e.Iditem)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("IDITEM");

                entity.Property(e => e.Idplaza)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IDPLAZA")
                    .IsFixedLength();

                entity.Property(e => e.Idusuario)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Idvende)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IDVENDE")
                    .IsFixedLength();

                entity.Property(e => e.Idzona)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IDZONA")
                    .IsFixedLength();

                entity.Property(e => e.Indcpitra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INDCPITRA")
                    .IsFixedLength();

                entity.Property(e => e.LineaImpuesto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ncf)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NCF");

                entity.Property(e => e.NcfModificado)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NCF_Modificado");

                entity.Property(e => e.Nittra)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NITTRA");

                entity.Property(e => e.Nreserva)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NRESERVA")
                    .IsFixedLength();

                entity.Property(e => e.Numdoctra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMDOCTRA")
                    .IsFixedLength();

                entity.Property(e => e.Numefac)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NUMEFAC");

                entity.Property(e => e.Porretetra)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("PORRETETRA");

                entity.Property(e => e.Refefac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("REFEFAC");

                entity.Property(e => e.Serie)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SERIE");

                entity.Property(e => e.Statustra)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATUSTRA")
                    .IsFixedLength();

                entity.Property(e => e.SubLineaImpuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TasaCambio).HasColumnType("money");

                entity.Property(e => e.Tasacambio1)
                    .HasColumnType("money")
                    .HasColumnName("TASACAMBIO1");

                entity.Property(e => e.Tasacambio2)
                    .HasColumnType("money")
                    .HasColumnName("TASACAMBIO2");

                entity.Property(e => e.Tipofac)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TIPOFAC")
                    .IsFixedLength();

                entity.Property(e => e.Valormoneda)
                    .HasColumnType("money")
                    .HasColumnName("VALORMONEDA");

                entity.Property(e => e.Valormoneda1)
                    .HasColumnType("money")
                    .HasColumnName("VALORMONEDA1");

                entity.Property(e => e.Valormoneda2)
                    .HasColumnType("money")
                    .HasColumnName("VALORMONEDA2");

                entity.Property(e => e.Valortra)
                    .HasColumnType("money")
                    .HasColumnName("VALORTRA");

                entity.Property(e => e.Vencefac)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENCEFAC")
                    .IsFixedLength();

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Voucher)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });*/

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
