using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Persistence
{
    public interface IDataContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Supplier> Suppliers { get; set; }

        DatabaseFacade Database { get; }
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}