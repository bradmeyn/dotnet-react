using Microsoft.EntityFrameworkCore;


namespace Api.Models
{
    public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
   {
   }

   public DbSet<Client> Clients { get; set; } = null!;

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       // Configure Client entity to use PostgreSQL UUID generation
       modelBuilder.Entity<Client>(entity =>
       {
           entity.HasKey(e => e.Id);
           entity.Property(e => e.Id)
               .HasDefaultValueSql("gen_random_uuid()")  // Use PostgreSQL's UUID generation
               .ValueGeneratedOnAdd(); // Mark as generated on add to database
       });
   }
}
}