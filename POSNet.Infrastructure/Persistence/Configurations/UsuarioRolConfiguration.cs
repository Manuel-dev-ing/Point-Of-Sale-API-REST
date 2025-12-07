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
    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> entity)
        {

            entity.HasKey(e => new { e.IdRol, e.IdUsuario }).HasName("PK_UsuarioRol");

            entity.ToTable("usuario_rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario");



        }
    }
}
