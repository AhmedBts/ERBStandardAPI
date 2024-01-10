using Domain.Entities.MainModule.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.MainModule.Master
{
    public class M_850DocTypeSubLdgTypeConfiguration: IEntityTypeConfiguration<M_850DocTypeSubLdgType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<M_850DocTypeSubLdgType> builder)
        {
            builder.HasKey(x => x.Serial);
            builder
    .HasIndex(i => new { i.Kind, i.DocTypeCode })
    .IsUnique();

            builder.HasOne(x => x.subLdgType).WithMany(x => x.M_850DocTypeSubLdgTypes).HasForeignKey(x =>x.SubLdgTypeCode).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.m_850DocType).WithMany(x => x.M_850DocTypeSubLdgTypes).HasForeignKey(x => new {x.Kind,x.DocTypeCode}).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
