using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Sales
{
    public class TrxHConfig : IEntityTypeConfiguration<TrxH>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrxH> builder)
        {

            builder.HasKey(x => new {
                x.BranchCode,
              
        
                x.Year,
                x.Type,
                x.Serial
            });
            builder.Property(x => x.BranchCode).ValueGeneratedNever
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