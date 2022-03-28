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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.CommentId).UseIdentityColumn();
            builder.Property(x => x.CommentText).IsRequired().HasMaxLength(400);
            builder.Property(x => x.CommentTitle).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId);
            builder.ToTable("Comments");
        }
    }
}
