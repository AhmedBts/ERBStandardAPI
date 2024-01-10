using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Sales
{
    internal class OrderDConfig : IEntityTypeConfiguration<OrderD>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderD> builder)
        {

            builder.HasKey(x => new {
                x.BranchCode,
                x.ProcessType
        ,
                x.Year,
                x.Type,
                x.Serial,x.LineNo
            });
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

            builder.Property(x => x.LineNo).ValueGeneratedNever
              ();
            builder.HasOne("orderh").WithMany("orderd").HasForeignKey(
           "BranchCode", "ProcessType", "Type", "Year", "Serial").OnDelete(DeleteBehavior.Cascade);


        }
    }
}
