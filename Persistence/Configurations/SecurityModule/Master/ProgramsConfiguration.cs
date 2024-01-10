using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations
{
    public class ProgramsConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Program> entity)

        {
            entity.HasKey(e => new { e.ProgId });

            entity.Property(e => e.ProgId).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.ArabicName).HasMaxLength(100);

            entity.Property(e => e.Description).HasMaxLength(100);

            entity.Property(e => e.FormName).HasMaxLength(100);

            entity.Property(e => e.HaveDelete).HasDefaultValueSql("((1))");

            entity.Property(e => e.HaveEdit).HasDefaultValueSql("((1))");

        

            entity.Property(e => e.HaveInsert).HasDefaultValueSql("((1))");

            entity.Property(e => e.HavePrint).HasDefaultValueSql("((1))");

            entity.Property(e => e.HaveRead).HasDefaultValueSql("((1))");

          

            entity.Property(e => e.LatinName).HasMaxLength(100);


            entity.Property(e => e.Parameters)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.ParentId)
                .HasColumnName("ParentID")
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.Url)
                .HasColumnName("URL")
                .HasMaxLength(100)
                .IsUnicode(false);


        }
    }
}
