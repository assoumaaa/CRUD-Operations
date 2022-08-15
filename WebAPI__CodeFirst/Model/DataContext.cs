using Microsoft.EntityFrameworkCore;

namespace WebAPI__CodeFirst.Model
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
