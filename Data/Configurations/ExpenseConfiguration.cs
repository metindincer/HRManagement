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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.ExpenseId);
            builder.Property(x => x.ExpenseId).UseIdentityColumn();
            builder.Property(x => x.ExpenseName).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Confirm).IsRequired();
            builder.Property(x => x.DocumentPathAboutSpending).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Expenses).HasForeignKey(x => x.UserId);
            
            builder.ToTable("Expenses");
        }
    }
}
