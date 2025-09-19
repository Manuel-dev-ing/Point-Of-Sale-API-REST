using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSNET.Domain.Entities;

namespace POSNet.Infrastructure.Persistence.Configurations
{
    public class ComprasConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Compras");

            entity.ToTable("compras");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NumeroCompra)
                .IsUnicode(false)
                .HasColumnName("numero_compra");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK_compras_proveedores");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_compras_usuarios");


        }
    }
}
