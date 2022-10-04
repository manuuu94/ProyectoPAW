using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class PROYECTO_PAWContext : DbContext
    {
        public PROYECTO_PAWContext()
        {
        }

        public PROYECTO_PAWContext(DbContextOptions<PROYECTO_PAWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<ClientesAtendido> ClientesAtendidos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;

        //public virtual DbSet<EmpleadoNuevo> EmpleadosNuevos { get; set; } = null!;
        public virtual DbSet<Usuario> usuario { get; set; } = null!;
        public virtual DbSet<InventarioServicio> InventarioServicios { get; set; } = null!;
        public virtual DbSet<MetodosPago> MetodosPagos { get; set; } = null!;
        public virtual DbSet<RegistroCompra> RegistroCompras { get; set; } = null!;
        public virtual DbSet<RegistrosInventario> RegistrosInventarios { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7HTT7HMN\\SQLEXPRESS;Database=PROYECTO_PAW;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__CARRITO__BA497EFEA47028C7");

                entity.ToTable("CARRITO");

                entity.Property(e => e.IdProd).HasColumnName("ID_PROD");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("PRECIO");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARRITO__ID_PROD__5DCAEF64");
            });

            modelBuilder.Entity<ClientesAtendido>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTES__23A341302791DBCE");

                entity.ToTable("CLIENTES_ATENDIDOS");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA_CLIENTE");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CLIENTE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.ClientesAtendidos)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENTES___ID_CO__4D94879B");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__EMPLEADO__922CA2691FCA5160");

                entity.ToTable("EMPLEADOS");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO2");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_INGRESO");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Passhash)
                    .HasMaxLength(150)
                    .HasColumnName("PASSHASH")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");


                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLEADOS__ID_RO__4222D4EF");
            });

            modelBuilder.Entity<InventarioServicio>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__INVENTAR__88BD03579F61C64B");

                entity.ToTable("INVENTARIO_SERVICIOS");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.CantidadDisponible).HasColumnName("CANTIDAD_DISPONIBLE");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("PRECIO");

                entity.Property(e => e.UrlImage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("URL_IMAGE");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.InventarioServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTARI__ID_SE__571DF1D5");
            });

            modelBuilder.Entity<MetodosPago>(entity =>
            {
                entity.HasKey(e => e.IdMetodo)
                    .HasName("PK__METODOS___93F65DA736236CC2");

                entity.ToTable("METODOS_PAGO");

                entity.Property(e => e.IdMetodo).HasColumnName("ID_METODO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<RegistroCompra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__REGISTRO__16C0FA95CD3D97C1");

                entity.ToTable("REGISTRO_COMPRAS");

                entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA_CLIENTE");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.IdMetodo).HasColumnName("ID_METODO");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CLIENTE");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_EMPLEADO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.TotalCompra)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("TOTAL_COMPRA");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroCompras)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTRO___ID_EM__4AB81AF0");

                entity.HasOne(d => d.IdMetodoNavigation)
                    .WithMany(p => p.RegistroCompras)
                    .HasForeignKey(d => d.IdMetodo)
                    .HasConstraintName("FK__REGISTRO___ID_ME__49C3F6B7");
            });

            modelBuilder.Entity<RegistrosInventario>(entity =>
            {
                entity.ToTable("REGISTROS_INVENTARIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACCION");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.RegistrosInventarios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK__REGISTROS__ID_SE__5AEE82B9");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__ROLES__203B0F6818F6991B");

                entity.ToTable("ROLES");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK__ROLES__ID_SERVIC__5070F446");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__SERVICIO__C8BDE0EB60104655");

                entity.ToTable("SERVICIOS");

                entity.Property(e => e.IdServicio).HasColumnName("ID_SERVICIO");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_SERVICIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
