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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.CompanyId).UseIdentityColumn();
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(70);
            builder.ToTable("Companies");

        }
    }
}

