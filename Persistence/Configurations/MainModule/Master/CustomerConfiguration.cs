using Domain.Entities.MainModule.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Persistence.Configurations.Codes
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustName)
                .IsRequired();
            builder.Property(x => x.CustLatName)
            .IsRequired();
            builder.HasKey(x => x.CustCode);
            builder.Property(x => x.CustCode).ValueGeneratedNever();
          
           
        }
    }
}