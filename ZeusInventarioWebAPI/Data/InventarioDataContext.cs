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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
