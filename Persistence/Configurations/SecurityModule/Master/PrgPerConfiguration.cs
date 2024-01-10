using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations
{
    public class PrgPerConfiguration : IEntityTypeConfiguration<PrgPer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PrgPer> entity)

        {
            entity.HasKey(e => new { e.UserId, e.ProgId });

            entity.Property(e => e.UserId)
               .ValueGeneratedNever();

           

            entity.Property(e => e.ProgId)
                .HasColumnType("decimal(18, 0)")
                .HasComment("كود الشاشة");

            entity.Property(e => e.Delete).HasComment("صلاحية حذف بيانات");

            entity.Property(e => e.Edit).HasComment("صلاحية تعديل بيانات");

          

            entity.Property(e => e.Insert).HasComment("صلاحية إدخال بيانات");

            entity.Property(e => e.Print).HasComment("صلاحية الطباعة");

            entity.Property(e => e.Read).HasComment("صلاحية قراءة بيانات");

      


        }
    }
}
