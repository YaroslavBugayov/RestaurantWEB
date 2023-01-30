using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pricelist> Pricelists { get; set; }
        public ApplicationContext() : base("name=RestaurantDB") 
        {
            Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<User>().Property(user => user.Username).HasMaxLength(25);

            dbModelBuilder
                .Entity<Dish>()
                .HasMany<Ingredient>(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .Map(di =>
                {
                    di.MapLeftKey("DishRefId");
                    di.MapRightKey("IngredientRefId");
                    di.ToTable("DishesIngredients");
                });

            dbModelBuilder
                .Entity<Pricelist>()
                .HasRequired<Dish>(p => p.Dish)
                .WithMany(d => d.Pricelists)
                .HasForeignKey<int>(p => p.DishId);

            dbModelBuilder
                .Entity<Pricelist>()
                .HasRequired<Size>(p => p.Size)
                .WithMany(s => s.Pricelists)
                .HasForeignKey<int>(p => p.SizeId);

            dbModelBuilder
                .Entity<Order>()
                .HasMany<Pricelist>(o => o.Pricelists)
                .WithMany(p => p.Orders)
                .Map(op =>
                {
                    op.MapLeftKey("OrderRefId");
                    op.MapRightKey("PricelistRefId");
                    op.ToTable("OrdersPricelists");
                });

            dbModelBuilder
                .Entity<Order>()
                .HasRequired<User>(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey<int>(o => o.UserId);

        }
    }
}
