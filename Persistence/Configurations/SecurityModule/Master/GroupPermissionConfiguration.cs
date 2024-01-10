

using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GroupPermission> entity)

        {
            entity.HasKey(e => new { e.GroupCode, e.ProgId });

            entity.Property(e => e.GroupCode).ValueGeneratedNever();

            entity.Property(e => e.ProgId).HasColumnType("decimal(18, 0)");
        }

    }
}
