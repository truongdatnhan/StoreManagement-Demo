using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configs
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("Invoice_Detail");
            builder.HasKey(rd => rd.Id);
            //One-to-many with Product
            builder.HasOne(rd => rd.Product).WithMany(p => p.InvoiceDetails).HasForeignKey(rd => rd.ProductId);
            //One-to-many with Receipt
            builder.HasOne(rd => rd.Invoice).WithMany(r => r.InvoiceDetails).HasForeignKey(rd => rd.InvoiceId);
        }
    }
}