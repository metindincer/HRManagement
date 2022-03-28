using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BreakConfiguration : IEntityTypeConfiguration<Break>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Break> builder)
        {
            builder.HasKey(x => x.BreakId);
            builder.Property(x => x.BreakId).UseIdentityColumn();
            builder.Property(x => x.BreakName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.StopTime).IsRequired();
            
            builder.ToTable("Breaks");
        }
    }
}
