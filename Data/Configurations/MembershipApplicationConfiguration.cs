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
    public class MembershipApplicationConfiguration : IEntityTypeConfiguration<MembershipApplication>
    {
        public void Configure(EntityTypeBuilder<MembershipApplication> builder)
        {
            builder.HasKey(x => x.ApplicationId);
            builder.Property(x => x.ApplicationId).UseIdentityColumn();
            builder.Property(x => x.ApplicationType).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Confirm).IsRequired();
            builder.HasOne(x => x.Company).WithMany(x => x.MembershipApplications).HasForeignKey(x => x.CompanyId);

            builder.ToTable(" MembershipApplications");
        }

    }
}
    

