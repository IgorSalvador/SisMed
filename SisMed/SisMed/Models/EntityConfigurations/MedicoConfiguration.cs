using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisMed.Models.Entities;

namespace SisMed.Models.EntityConfigurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            // Identifica o nome da tabela
            builder.ToTable("Medicos");

            // Identifica a primary key da tabela
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CRM)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(x => x.CRM)
                .IsUnique();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
