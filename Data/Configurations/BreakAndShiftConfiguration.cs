using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BreakAndShiftConfiguration : IEntityTypeConfiguration<BreakAndShift>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BreakAndShift> builder)
        {
            builder.HasKey(x => new { x.ShiftId, x.BreakId });

            builder.ToTable("BreakAndShifts");

        }
    }
}
