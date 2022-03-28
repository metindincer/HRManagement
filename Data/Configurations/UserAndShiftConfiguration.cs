using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
    public class UserAndShiftConfiguration : IEntityTypeConfiguration<UserAndShift>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAndShift> builder)
        {
            builder.HasKey(x => new { x.ShiftId, x.UserId });
            builder.ToTable("UserAndShifts");

        }
    }
}
