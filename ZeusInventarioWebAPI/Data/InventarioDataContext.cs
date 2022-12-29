using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Data
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

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Bodega> Bodegas { get; set; } = null!;
        public virtual DbSet<Clasificacion> Clasificacions { get; set; } = null!;
        public virtual DbSet<DocumentoItem> DocumentoItems { get; set; } = null!;
        public virtual DbSet<Existencia> Existencia { get; set; } = null!;
        public virtual DbSet<FacturaDeCliente> FacturaDeClientes { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Lote> Lotes { get; set; } = null!;
        public virtual DbSet<ModalidadesVenta> ModalidadesVentas { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;
        public virtual DbSet<UnidadMedidaArticulo> UnidadMedidaArticulos { get; set; } = null!;
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; } = null!;

        public virtual DbSet<MovimientoItem> MovimientoItems { get; set; } = null!;
        public virtual DbSet<Transac> Transacs { get; set; } = null!;


        //CONEXIÓN A BASE DE DATOS QUE YA SE ENCUENTRA EN appsettings.json
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= 192.168.0.85; Database= Inventario; User ID= Admin; pwd=102024;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.IdArticulo).ValueGeneratedOnAdd();

                entity.Property(e => e.Categoria).HasDefaultValueSql("('')");

                entity.Property(e => e.Centrocosto).HasDefaultValueSql("('')");

                entity.Property(e => e.Cifdolares).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cifeuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.Codigo).HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFacturacion).HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoFacturacion2).HasDefaultValueSql("('')");

                entity.Property(e => e.ComplementoAjusteInflacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoCentroCosto).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoCosto).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoCosto1).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoCosto2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoCosto3).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoInventario).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoInventarioRemisionado).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoInventarioxEntregar).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoIvaconsumo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoIvaventas).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoVenta).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoVenta1).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoVenta2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComplementoVenta3).HasDefaultValueSql("((0))");

                entity.Property(e => e.Complementoiva).HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaCosto).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaGastoProvision).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaInventario).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaInventarioRemisionado).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaInventarioxEntregar).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaIvaconsumo).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaIvaventas).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaVenta).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaajusteInflacion).HasDefaultValueSql("('')");

                entity.Property(e => e.Cuentaiva).HasDefaultValueSql("('')");

                entity.Property(e => e.DemandaPromedio).HasDefaultValueSql("((0))");

                entity.Property(e => e.DesHabilitado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion).HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionOtroIdioma).HasDefaultValueSql("('')");

                entity.Property(e => e.DetallesTecnicos).HasDefaultValueSql("('')");

                entity.Property(e => e.DiasGarantia).HasDefaultValueSql("((0))");

                entity.Property(e => e.Diasdeinventario).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigeSerie).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigirCentroCosto).HasDefaultValueSql("((0))");

                entity.Property(e => e.FactorDeSeguridad).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fcreacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaUltimaModificacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fobdolares).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fobeuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.Formula).HasDefaultValueSql("('')");

                entity.Property(e => e.Frecuenciadecompra).HasDefaultValueSql("((8))");

                entity.Property(e => e.GradosContenidos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Grupo).HasDefaultValueSql("('')");

                entity.Property(e => e.GrupoAuxiliar).HasDefaultValueSql("('')");

                entity.Property(e => e.GrupoFacturacion).HasDefaultValueSql("('')");

                entity.Property(e => e.GrupoFacturacion2).HasDefaultValueSql("('')");

                entity.Property(e => e.ImpuestoConsumo).HasDefaultValueSql("((0))");

                entity.Property(e => e.LineaProduccion).HasDefaultValueSql("('')");

                entity.Property(e => e.Maximo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Minimo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre).HasDefaultValueSql("('')");

                entity.Property(e => e.Peso).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pesoconempaque).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeDescuento).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeGravamen).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeIva).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeRentabilidad).HasDefaultValueSql("((0))");

                entity.Property(e => e.Porcentajecomision).HasDefaultValueSql("((0))");

                entity.Property(e => e.PosicionArancelaria).HasDefaultValueSql("('')");

                entity.Property(e => e.Presentacion).HasDefaultValueSql("('')");

                entity.Property(e => e.PuntoDeReorden).HasDefaultValueSql("((0))");

                entity.Property(e => e.TiempoReposicion).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tipo).HasDefaultValueSql("('')");

                entity.Property(e => e.UnidadPorEmpaque).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadesContenidaEmpaque).HasDefaultValueSql("((1))");

                entity.Property(e => e.Valorización).HasDefaultValueSql("('')");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Volumen).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulo_Grupo");
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.Property(e => e.AuxiliarAjusteInflacion).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarCentroCosto).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarInventarioRemisionado).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarInventarioxEntregar).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarIvaconsumo).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarIvaventas).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarPartidaAjusteInflacion).HasDefaultValueSql("('')");

                entity.Property(e => e.BodegaImportacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.BodegaPrincipal).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdenBodega).ValueGeneratedOnAdd();

                entity.Property(e => e.IncluirCalculoReorden).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoAplicarAjusteInflacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.Property(e => e.IdenClasificacion).ValueGeneratedOnAdd();

                entity.Property(e => e.Md).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mee).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mrt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mue).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<DocumentoItem>(entity =>
            {
                entity.Property(e => e.Aprobado).HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloIndirectoNoValorizaFormula).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostoAjustado).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostoTotalOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descargardeinventarios).HasDefaultValueSql("((1))");

                entity.Property(e => e.Detalle).HasDefaultValueSql("('')");

                entity.Property(e => e.Empaques).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaGrabacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FletesUnidad2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Iden).ValueGeneratedOnAdd();

                entity.Property(e => e.ImportacionFletes).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImportacionOtrosGastos).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImportacionSeguro).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImpuestoConsumo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemsRelacionado).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenGrabacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.OtrosCostosOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeIvamaxDeducible).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeimpuestoOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioTotal2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioUnidad2).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioxLote).HasDefaultValueSql("((0))");

                entity.Property(e => e.Referencia).HasDefaultValueSql("('')");

                entity.Property(e => e.Seriales).HasDefaultValueSql("('')");

                entity.Property(e => e.TasaCalculo).HasDefaultValueSql("((1))");

                entity.Property(e => e.TasaCambio).HasDefaultValueSql("((1))");

                entity.Property(e => e.TasaNiif).HasDefaultValueSql("((1))");

                entity.Property(e => e.TotalDescuentoCompra2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoCompraOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoVenta2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoVentaOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalImpoConCompras2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalImpoConDescontable2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalImpoConVentas2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvacompras2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvacomprasOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvaconsumo2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvadescontable2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvaventas2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalIvaventasOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorImpuestoConsumo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorImpuestoConsumo2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorImpuestoConsumoOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorUnidadOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Existencia>(entity =>
            {
                entity.HasKey(e => new { e.Articulo, e.Lote, e.Bodega, e.Clasificacion, e.Ubicacion });

                entity.Property(e => e.Codigo).ValueGeneratedOnAdd();

                entity.Property(e => e.Serial).HasDefaultValueSql("(' ')");

                entity.Property(e => e.ValorSinInflacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Existencia_Articulo");

                entity.HasOne(d => d.BodegaNavigation)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.Bodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Existencia_Bodega");

                entity.HasOne(d => d.ClasificacionNavigation)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.Clasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Existencia_Clasificacion");

                entity.HasOne(d => d.LoteNavigation)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.Lote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Existencia_Lote");

                entity.HasOne(d => d.UbicacionNavigation)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.Ubicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Existencia_Ubicacion");
            });

            modelBuilder.Entity<FacturaDeCliente>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("PK_FacturaCli")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.Fecha, e.Estado }, "Estado_Fecha")
                    .IsClustered();

                entity.Property(e => e.Anticipo).HasDefaultValueSql("('')");

                entity.Property(e => e.Auxiliar).HasDefaultValueSql("('')");

                entity.Property(e => e.CentroCosto).HasDefaultValueSql("('')");

                entity.Property(e => e.Cliente).HasDefaultValueSql("('')");

                entity.Property(e => e.ComisionLiquidada).HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaAnticipo).HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaPago).HasDefaultValueSql("('')");

                entity.Property(e => e.DespachoCiudad).HasDefaultValueSql("('')");

                entity.Property(e => e.DespachoDireccion).HasDefaultValueSql("('')");

                entity.Property(e => e.DespachoTransportadora).HasDefaultValueSql("('')");

                entity.Property(e => e.Despachocliente).HasDefaultValueSql("('')");

                entity.Property(e => e.Detalle).HasDefaultValueSql("('')");

                entity.Property(e => e.DiasCreditos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Documento).HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentoRev).HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado).HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FormaPago).HasDefaultValueSql("('')");

                entity.Property(e => e.Fuente).HasDefaultValueSql("('')");

                entity.Property(e => e.IdenFacturadecliente).ValueGeneratedOnAdd();

                entity.Property(e => e.ListaDePrecios).HasDefaultValueSql("('')");

                entity.Property(e => e.Moneda).HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroCuotas).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObservacionInterna).HasDefaultValueSql("('')");

                entity.Property(e => e.Serie).HasDefaultValueSql("('')");

                entity.Property(e => e.Tasacambio).HasDefaultValueSql("((1))");

                entity.Property(e => e.TipoFactura)
                    .HasDefaultValueSql("('FA')")
                    .IsFixedLength();

                entity.Property(e => e.Usuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorAnticipo).HasDefaultValueSql("((0))");

                entity.Property(e => e.VencimientoInicial).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vendedor).HasDefaultValueSql("('')");

                entity.HasOne(d => d.ModalidadVentasNavigation)
                    .WithMany(p => p.FacturaDeClientes)
                    .HasForeignKey(d => d.ModalidadVentas)
                    .HasConstraintName("FK_FacturaDeCliente_ModalidadesVentas");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("Codigo")
                    .IsClustered(false);

                entity.Property(e => e.AsignacionBodega).HasDefaultValueSql("((0))");

                entity.Property(e => e.AuxiliarAjusteInflacion).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarCentroCosto).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarInventarioRemisionado).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarInventarioxEntregar).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarIvaconsumo).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarIvaventas).HasDefaultValueSql("('')");

                entity.Property(e => e.AuxiliarPartidaAjusteInflacion).HasDefaultValueSql("('')");

                entity.Property(e => e.Concepto).IsFixedLength();

                entity.Property(e => e.CuentaGastoProvision).HasDefaultValueSql("('')");

                entity.Property(e => e.IdenGrupo).ValueGeneratedOnAdd();

                entity.Property(e => e.NoAplicarAjusteInflacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajeComision).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PadreNavigation)
                    .WithMany(p => p.InversePadreNavigation)
                    .HasForeignKey(d => d.Padre)
                    .HasConstraintName("Ser subgrupo de");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.Articulo, e.Bodega, e.Ubicacion, e.Lote, e.Clasificacion })
                    .IsClustered(false);

                entity.HasIndex(e => e.Codigo, "IX_Items_1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Serial).HasDefaultValueSql("('')");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Articulo");

                entity.HasOne(d => d.BodegaNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Bodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Bodega");

                entity.HasOne(d => d.ClasificacionNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Clasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Clasificacion");

                entity.HasOne(d => d.LoteNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Lote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Lote");

                entity.HasOne(d => d.UbicacionNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Ubicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Ubicacion");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Lote1");

                entity.Property(e => e.Deshabilitado).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdenLote).ValueGeneratedOnAdd();

                entity.Property(e => e.PrecioBruto).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioNeto).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioNetoEmpaque).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ModalidadesVenta>(entity =>
            {
                entity.Property(e => e.IdenModalidadesventas).ValueGeneratedOnAdd();

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.AfectaExistenciaPosicionArancelaria).HasDefaultValueSql("((0))");

                entity.Property(e => e.Aprobacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoLiquidar).HasDefaultValueSql("((0))");

                entity.Property(e => e.Auxiliarventa).HasDefaultValueSql("('')");

                entity.Property(e => e.Ciclo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfiguracionCuenta).HasDefaultValueSql("((0))");

                entity.Property(e => e.ControlDeInventario).HasDefaultValueSql("((0))");

                entity.Property(e => e.ControlDeProcesos).HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaPuenteAjusteporRecosteo).HasDefaultValueSql("('')");

                entity.Property(e => e.DescripcionDocument).HasDefaultValueSql("('')");

                entity.Property(e => e.Disponibles).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentoContable).HasDefaultValueSql("('')");

                entity.Property(e => e.ExigeBodega).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigeClasificacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigeLote).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigeSerie).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExigeUbicacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.Factor).HasDefaultValueSql("((1))");

                entity.Property(e => e.FactorCr).HasDefaultValueSql("((0))");

                entity.Property(e => e.FactorDb).HasDefaultValueSql("((0))");

                entity.Property(e => e.FactorIngresoRpt).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImpresionDirecta).HasDefaultValueSql("((0))");

                entity.Property(e => e.ListarPuntoDeReorden).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaConsecutivoManual).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaCostoOtraMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaDcto).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaImpuestoAlConsumo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaIva).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaOtrosCostos).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManejaPosicionArancelaria).HasDefaultValueSql("((0))");

                entity.Property(e => e.Orden).HasDefaultValueSql("((0))");

                entity.Property(e => e.PuntoDeReorden).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reporte).HasDefaultValueSql("('')");

                entity.Property(e => e.Reproceso).HasDefaultValueSql("((0))");

                entity.Property(e => e.Usar).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .IsClustered(false);

                entity.Property(e => e.IdenUbicacion).ValueGeneratedOnAdd();

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.Property(e => e.IdenUnidad).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UnidadMedidaArticulo>(entity =>
            {
                entity.HasKey(e => new { e.Articulo, e.IdenUnidad });

                entity.Property(e => e.IdenUnidadmedidaArticulo).ValueGeneratedOnAdd();

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.UnidadMedidaArticulos)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnidadMedida_Articulo_Articulo");

                entity.HasOne(d => d.IdenUnidadNavigation)
                    .WithMany(p => p.UnidadMedidaArticulos)
                    .HasPrincipalKey(p => p.Iden)
                    .HasForeignKey(d => d.IdenUnidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnidadMedida_Articulo_UnidadMedida");
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .IsClustered(false);

                entity.HasIndex(e => e.Iden, "IX_UnidadMedida")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Iden).ValueGeneratedOnAdd();

                entity.Property(e => e.Tipo).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<MovimientoItem>(entity =>
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
            });
                      
            modelBuilder.Entity<Maevende>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MAEVENDE");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTO");

                entity.Property(e => e.Contactoa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTOA");

                entity.Property(e => e.Dirconta)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRCONTA");

                entity.Property(e => e.Dircontaa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRCONTAA");

                entity.Property(e => e.Dircorres)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRCORRES");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Dirgerente)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DIRGERENTE");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Emailconta)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCONTA");

                entity.Property(e => e.Emailcontaa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCONTAA");

                entity.Property(e => e.Emailgeren)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAILGEREN");

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Gerente)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GERENTE");

                entity.Property(e => e.IdenMaevende)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Iden_maevende");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(25)
                    .IsUnicode(false);

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

                entity.Property(e => e.MetaVenta).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Nombvende)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOMBVENDE");

                entity.Property(e => e.Pcomision)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PComision");

                entity.Property(e => e.Pdescuento)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PDescuento");

                entity.Property(e => e.Ppenalidad)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("PPenalidad");

                entity.Property(e => e.Telconta)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELCONTA");

                entity.Property(e => e.Telcontaa)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELCONTAA");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Telgerente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELGERENTE");

                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Website)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("CLIENTES");

                entity.Property(e => e.Autorizacion).HasColumnName("AUTORIZACION");
                entity.Property(e => e.BlCupoCreditoPorMoneda).HasColumnName("bl_CupoCreditoPorMoneda");
                entity.Property(e => e.Bloqueo).HasColumnName("BLOQUEO");
                entity.Property(e => e.Bloqueopornit).HasColumnName("BLOQUEOPORNIT");
                entity.Property(e => e.CentroCosto)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Ciudad)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");
                entity.Property(e => e.CodAlterno)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.Codicta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CODICTA");
                entity.Property(e => e.Codigodane)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CODIGODANE");
                entity.Property(e => e.Codigoubicacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODIGOUBICACION");
                entity.Property(e => e.Contacto)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTO");
                entity.Property(e => e.Contactoa)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTOA");
                entity.Property(e => e.Cupocre)
                    .HasColumnType("money")
                    .HasColumnName("CUPOCRE");
                entity.Property(e => e.Diagracia).HasColumnName("DIAGRACIA");
                entity.Property(e => e.Diplazo).HasColumnName("DIPLAZO");
                entity.Property(e => e.Dirconta)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DIRCONTA");
                entity.Property(e => e.Dircontaa)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DIRCONTAA");
                entity.Property(e => e.Dircorres)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DIRCORRES");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");
                entity.Property(e => e.Dirgerente)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DIRGERENTE");
                entity.Property(e => e.Divpolitica)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DIVPOLITICA");
                entity.Property(e => e.Email)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.Emailconta)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCONTA");
                entity.Property(e => e.Emailcontaa)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCONTAA");
                entity.Property(e => e.Emailgeren)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAILGEREN");
                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FAX");
                entity.Property(e => e.FormatoDeFactura)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FormatoDeFacturaRemision)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FormatoDePedido)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FormatoDeRemision)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Fpagcontado).HasColumnName("FPAGCONTADO");
                entity.Property(e => e.Fpagcredito).HasColumnName("FPAGCREDITO");
                entity.Property(e => e.Gerente)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GERENTE");
                entity.Property(e => e.GrEmpresarial)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.Idcliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IDCLIENTE");
                entity.Property(e => e.IdenClientes)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Iden_clientes");
                entity.Property(e => e.Idtercero)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IDTERCERO");
                entity.Property(e => e.Idvende)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("IDVENDE");
                entity.Property(e => e.Idzona)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("IDZONA");
                entity.Property(e => e.IndNcf).HasColumnName("IndNCF");
                entity.Property(e => e.IntMora).HasColumnType("numeric(18, 4)");
                entity.Property(e => e.Item)
                    .HasMaxLength(16)
                    .IsUnicode(false);
                entity.Property(e => e.Pais)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.ProveedorTecnologico)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.Razoncial)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("RAZONCIAL");
                entity.Property(e => e.Segmento)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENTO");
                entity.Property(e => e.Tag)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("TAG");
                entity.Property(e => e.Telconta)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELCONTA");
                entity.Property(e => e.Telcontaa)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELCONTAA");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");
                entity.Property(e => e.Telgerente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TELGERENTE");
                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.TipoCliente)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.TipoNotificacionFe)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TipoNotificacion_FE");
                entity.Property(e => e.UsoLibre).IsUnicode(false);
                entity.Property(e => e.VersionDeLaFila)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Website)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");
            });

            modelBuilder.Entity<PedidoDeCliente>(entity =>
            {
                entity.HasKey(e => e.Consecutivo).HasName("PK_PedidoCli");

                entity.ToTable("PedidoDeCliente");

                entity.HasIndex(e => e.DocumentoRev, "DocumentoRev");

                entity.HasIndex(e => new { e.Aplicacion, e.TipoDocumentoExterno, e.ConsecutivoExterno, e.Caja }, "IX_PedidoDeCliente");

                entity.HasIndex(e => e.Cliente, "IX_PedidoDeCliente_Cliente");

                entity.HasIndex(e => e.Estado, "IX_PedidoDeCliente_Estado");

                entity.HasIndex(e => new { e.Vendedor, e.Fecha }, "IX_PedidoDeCliente_Vendedor_Fecha");

                entity.Property(e => e.Consecutivo).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Anticipo)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Aplicacion).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Aprueba).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.AutorOrdenCompra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Auxiliar)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Caja)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.CentroCosto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Clasificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Normal')");
                entity.Property(e => e.Cliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.ConsecutivoExterno).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.CuentaAnticipo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.CuentaPago)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.DespachoCiudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.DespachoCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.DespachoDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.DespachoTransportadora)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Detalle)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasColumnName("detalle");
                entity.Property(e => e.DiasCreditos)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.DocumentoRev)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Fecha)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("smalldatetime");
                entity.Property(e => e.FechaEntrega)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("smalldatetime");
                entity.Property(e => e.FletePorUnidad).HasColumnType("numeric(18, 6)");
                entity.Property(e => e.FormaPago)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.IdenPedidodecliente)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Iden_pedidodecliente");
                entity.Property(e => e.ListaDePrecios)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.ModalidadVentas)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.NumeroCuotas)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.ObservacionInterna)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.ObservacionesDeAprobacion)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
                entity.Property(e => e.OrdenCompraCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.Preaprueba).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Tasacambio)
                    .HasDefaultValueSql("((1))")
                    .HasColumnType("numeric(18, 6)");
                entity.Property(e => e.TipoDocumentoExterno).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.Usuario)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("numeric(18, 0)");
                entity.Property(e => e.ValorAnticipo)
                    .HasDefaultValueSql("((0))")
                    .HasColumnType("money");
                entity.Property(e => e.VencimientoInicial)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("smalldatetime");
                entity.Property(e => e.Vendedor)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                entity.Property(e => e.YaFueAnalizadaPr).HasColumnName("YaFueAnalizadaPR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
