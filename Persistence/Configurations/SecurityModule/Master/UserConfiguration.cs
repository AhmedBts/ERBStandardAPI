using Microsoft.EntityFrameworkCore;
using Domain.Entities.SecurityModule.Master;

namespace Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.GroupId).IsRequired();
            builder.Property(x => x.BirthDay).HasColumnType("Date");
            builder.Property(x => x.Mobile).HasMaxLength(15);
            builder.Property(x => x.Mobile1).HasMaxLength(15);
        }
    }
    class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserLog> builder)
        {
            builder.HasKey(x => x.Id);

        
            builder.Property(x => x.CreatedAt).HasColumnType("datetime");
          
        }
    }
    class ActionTypeUserConfiguration : IEntityTypeConfiguration<ActionTypeUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ActionTypeUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActionTypeName).IsRequired()
                .HasMaxLength(200);

        }
    }
}
