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
    public class CiudadesConfiguration : IEntityTypeConfiguration<Ciudade>
    {
        public void Configure(EntityTypeBuilder<Ciudade> entity)
        {
            entity.ToTable("ciudades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");



        }
    }
}
