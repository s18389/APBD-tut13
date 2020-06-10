
using Microsoft.EntityFrameworkCore;

namespace APBD_tut13.Entities
{
    public class DbContextCreate : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Order { get; set; }

        public DbContextCreate()
        {

        }

        public DbContextCreate(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18389;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.ToTable("Customer");

                entity.HasMany(e => e.Orders).WithOne(p => p.Customer).HasForeignKey(p => p.IdClient).IsRequired();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.ToTable("Orders");
                entity.HasMany(e => e.Confectionery_Order).WithOne(p => p.Order).HasForeignKey(p => p.IdOrder).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
                entity.ToTable("Employee");
                entity.HasMany(e => e.Orders).WithOne(p => p.Employee).HasForeignKey(p => p.IdEmployee).IsRequired();
            });

            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfection);
                entity.Property(e => e.IdConfection).ValueGeneratedOnAdd();
                entity.ToTable("Confectionery");
                entity.HasMany(e => e.Confectionery_Order).WithOne(p => p.Confectionery).HasForeignKey(p => p.IdConfection).IsRequired();
            });

            modelBuilder.Entity<Confectionery_Order>(entity =>
            {
                entity.HasKey(e => e.IdConfection);
                entity.HasKey(e => e.IdOrder);
                entity.ToTable("Confectionery_Order");
            });
        }


    }
}
