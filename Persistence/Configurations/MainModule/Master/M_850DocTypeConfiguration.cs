using Domain.Entities.MainModule.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.MainModule.Master
{
    public class M_850DocTypeConfiguration: IEntityTypeConfiguration<M_850DocType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<M_850DocType> builder)
        {
            builder.Property(a => a.Serial).IsRequired();
            builder.Property(a=>a.Serial).UseIdentityColumn();  
        
            builder.HasKey(a => new {a.Kind,a.DocTypeCode});
            builder.Property(a => a.Kind).ValueGeneratedNever();
            builder.Property(a => a.DocTypeCode).ValueGeneratedNever();

        }

    }
    public class M_850FieldTypeConfiguration : IEntityTypeConfiguration<M_850FieldType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<M_850FieldType> builder)
        {
           

            builder.HasKey(a =>a.FieldTypeCode);
            builder.Property(a => a.FieldTypeCode).ValueGeneratedNever();
            builder.Property(a => a.FieldTypeAraName).HasMaxLength(128);
            builder.Property(a => a.FieldTypeLatName).HasMaxLength(128);
        }

    }
}
