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

    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.PermissionId);
            builder.Property(x => x.PermissionId).UseIdentityColumn();
            builder.Property(x => x.PermissionName).IsRequired().HasMaxLength(50);         
            builder.Property(x => x.Confirm).IsRequired();
            builder.Property(x => x.PermissionStartDate).IsRequired();
            builder.Property(x => x.PermissionEndDate).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Permissions).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.User).WithMany(x => x.Permissions).HasForeignKey(x => x.DirectorId);
            builder.HasOne(x => x.PermissionType).WithMany(x => x.Permissions).HasForeignKey(x => x.PermissionTypeId);




            builder.ToTable("Permissions");
        }
    }
}
