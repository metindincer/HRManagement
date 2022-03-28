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
    public class DocumentationConfiguration : IEntityTypeConfiguration<Documentation>
    {
        public void Configure(EntityTypeBuilder<Documentation> builder)
        {
            builder.HasKey(x => x.DocumentationId);
            builder.Property(x => x.DocumentationId).UseIdentityColumn();
            builder.Property(x => x.DocumentationName).IsRequired().HasMaxLength(70);
            builder.Property(x => x.DocumentationPath).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Documentations).HasForeignKey(x => x.UserId);
            builder.ToTable("Documentations");


        }
    }
}
