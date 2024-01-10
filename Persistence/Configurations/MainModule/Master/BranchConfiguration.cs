using Domain.Entities.MainModule.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.MainModule.Master
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Branch> builder)
        {
         
            builder.Property(x => x.BranchCode)
                .IsRequired();
           
            builder.HasKey(x => x.BranchCode);
            builder.Property(x => x.BranchCode).ValueGeneratedNever();

            builder.HasOne(c => c.Company).WithMany(a => a.branches).HasForeignKey(a=>a.CompanyCode).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
