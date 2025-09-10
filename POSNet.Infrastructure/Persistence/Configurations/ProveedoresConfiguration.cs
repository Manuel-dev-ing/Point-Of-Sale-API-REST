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
    public class ProveedoresConfiguration : IEntityTypeConfiguration<Proveedore>
    {
        public void Configure(EntityTypeBuilder<Proveedore> entity)
        {
            entity.ToTable("proveedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_proveedores_ciudades");
        }
    }
}
