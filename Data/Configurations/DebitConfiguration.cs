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
    public class DebitConfiguration : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.HasKey(x => x.DebitId);
            builder.Property(x => x.DebitId).UseIdentityColumn();
            builder.Property(x => x.DebitName).IsRequired().HasMaxLength(70);
            builder.Property(x => x.IsConfirm).IsRequired();
            builder.Property(x => x.Note).IsRequired().HasMaxLength(200);
            builder.HasOne(x => x.User).WithMany(x => x.Debits).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.User).WithMany(x => x.Debits).HasForeignKey(x => x.DirectorId);

            builder.ToTable("Debits");

        }
    }
}
