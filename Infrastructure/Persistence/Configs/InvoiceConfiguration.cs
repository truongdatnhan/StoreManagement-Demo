using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Persistence.Configs
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(r => r.Id);
            //One-to-many with Supplier
            builder.HasOne(r => r.Supplier).WithMany(s => s.Invoices).HasForeignKey(r => r.SupplierId);
        }
    }
}