using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccessLayer.Model;

namespace MovieSystem.DataAccessLayer.Context
{
    public partial class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id)
                            .IsRequired()
                            .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                            .IsRequired();

                entity.Property(e => e.Description)
                            .IsRequired();

                entity.Property(e => e.Rating)
                            .IsRequired();

                entity.Property(e => e.Image);

                entity.Property(e => e.Duration)
                            .IsRequired();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");
                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.IsDeleted).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

