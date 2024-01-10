using Domain.Entities.MainModule.Master;
using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Sales
{
    public class OrderHConfig : IEntityTypeConfiguration<OrderH>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderH> builder)
        {

        builder.HasKey(x => new { x.BranchCode,x.ProcessType
    ,x.Year,x.Type,x.Serial});
            builder.Property(x => x.BranchCode).ValueGeneratedNever
                ();
            builder.Property(x => x.ProcessType).ValueGeneratedNever
                ();

            builder.Property(x => x.Year).ValueGeneratedNever
                ();
            builder.Property(x => x.Type).ValueGeneratedNever
                ();
            builder.Property(x => x.Serial).ValueGeneratedNever
                ();
            builder.HasMany("orderd").WithOne("orderh").HasForeignKey("BranchCode", "ProcessType", "Type", "Year", "Serial")
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
