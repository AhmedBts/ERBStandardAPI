using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Sales
{
    public class TrxDConfig : IEntityTypeConfiguration<TrxD>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrxD> builder)
        {

            builder.HasKey(x => new {
                x.BranchCode,

                x.Year,
                x.Type,
                x.Serial,
                x.LineNum1,x.LineNum2
            });
            builder.Property(x => x.BranchCode).ValueGeneratedNever
                ();

            builder.Property(x => x.LineNum1).ValueGeneratedNever
               ();
            builder.Property(x => x.Year).ValueGeneratedNever
                ();
            builder.Property(x => x.Type).ValueGeneratedNever
                ();
            builder.Property(x => x.Serial).ValueGeneratedNever
                ();




        }
    }
}