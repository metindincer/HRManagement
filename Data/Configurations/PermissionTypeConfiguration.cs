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
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(x => x.PermissionTypeId);
            builder.Property(x => x.PermissionTypeId).UseIdentityColumn();
            builder.Property(x => x.PermissionName).IsRequired().HasMaxLength(50);

            builder.ToTable("Permission Types");

        }
    }
}
