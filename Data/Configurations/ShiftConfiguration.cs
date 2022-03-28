using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(x => x.ShiftId);
            builder.Property(x => x.ShiftId).UseIdentityColumn();
            builder.Property(x => x.ShiftName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            
            
            
            builder.HasOne(x => x.Company).WithMany(x => x.Shifts).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.User).WithMany(x => x.Shifts).HasForeignKey(x => x.UserId);




            builder.ToTable("Shifts");




        }
    }
}
