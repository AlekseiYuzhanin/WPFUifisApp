using Agent.Models;
using Microsoft.EntityFrameworkCore;

namespace Agent
{
    public class AgentContext : DbContext
    {
        public DbSet<Models.Agent> Agents { get; set; }
        public DbSet<AgentPriorityHistory> AgentPriorityHistories { get; set; }
        public DbSet<AgentType> AgentTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCostHistory> MaterialCostHistories { get; set; }
        public DbSet<MaterialSupplier> MaterialSuppliers { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\mssqllocaldb;Database=Agents;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(x =>
            {
                x.Property(x => x.CountInStock).IsRequired(false);
                x.Property(x => x.Image).IsRequired(false);
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(x => x.ProductTypeId).IsRequired(false);
                x.Property(x => x.Image).IsRequired(false);
                x.Property(x => x.Description).IsRequired(false);
                x.Property(x => x.ProductionPersonCount).IsRequired(false);
                x.Property(x => x.ProductionWorkshopNumber).IsRequired(false);
            });

            modelBuilder.Entity<ProductMaterial>(x =>
            {
                x.Property(x => x.Count).IsRequired(false);
            });

            modelBuilder.Entity<ProductMaterial>(x =>
            {
                x.HasKey(x => new { x.ProductId, x.MaterialId });
                x.HasOne(x => x.Product).WithMany(x => x.ProductMaterials).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
                x.HasOne(x => x.Material).WithMany(x => x.ProductMaterials).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<MaterialSupplier>(x =>
            {
                x.HasKey(x => new { x.SupplierId, x.MaterialId });
                x.HasOne(x => x.Supplier).WithMany(x => x.MaterialSuppliers).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.NoAction);
                x.HasOne(x => x.Material).WithMany(x => x.MaterialSuppliers).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
