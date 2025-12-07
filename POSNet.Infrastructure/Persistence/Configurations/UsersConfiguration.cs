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
    public class UsersConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("segundo_apellido");



        }
    }
}
