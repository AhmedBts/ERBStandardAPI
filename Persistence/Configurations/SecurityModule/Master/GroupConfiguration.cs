
using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations
{
   public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.GroupName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.GroupLatName).IsRequired().HasMaxLength(200);
            builder.HasKey(x => x.GroupId);
            builder.HasMany(c => c.Users).WithOne(x => x.Groups).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
   }
    }
}
