using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.SecurityModule.Master
{
    public class VerificationCodeConfiguration : IEntityTypeConfiguration<VerificationCode>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VerificationCode> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(vc => vc.IsUsed).HasDefaultValue(false);
            builder.HasOne(vc=>vc.User).WithMany(u=>u.VerificationCodes)
                .HasForeignKey(vc=>vc.UserId).OnDelete(DeleteBehavior.Cascade);              
        }
    }
}