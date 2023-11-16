using Microsoft.EntityFrameworkCore;

using EntitiesEF;

namespace ProviderEF
{
    public class LibraryDB : DbContext
    {
        private const string ConnectionString =
            @"Server=DESKTOP-OGU2J56;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;";

        public DbSet<Book> Books { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Issued> Issueds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(ent =>
            {
                ent.ToTable("categories_books");

                ent.HasKey(m => m.CategoryId)
                    .HasName("CategoryId");

                ent.Property(m => m.CategoryId)
                    .ValueGeneratedOnAdd();

                ent.Property(x => x.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Reader>(ent =>
            {
                ent.ToTable("readers");

                ent.HasKey(m => m.ReaderId)
                    .HasName("id_reader");

                ent.Property(x => x.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsRequired();

                ent.Property(x => x.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsRequired();

                ent.Property(x => x.Patronymic)
                    .HasColumnName("patronymic")
                    .HasMaxLength(80)
                    .IsRequired();

                ent.Property(e => e.CategoryId)
                    .HasColumnName("id_category");

                ent.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .IsRequired();

                ent.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                ent.HasOne(d => d.Category)
                    .WithMany(p => p.Readers)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(ent =>
            {
                ent.ToTable("genre_type");

                ent.HasKey(x => x.GenreId)
                    .HasName("id_genre");

                ent.Property(x => x.GenreId)
                    .ValueGeneratedOnAdd();

                ent.Property(x => x.Name)
                    .HasColumnName("name_genre")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Book>(ent =>
            {
                ent.ToTable("books");

                ent.HasKey(x => x.BookId)
                    .HasName("BookId");

                ent.Property(x => x.Name)
                    .HasColumnName("name_book")
                    .HasMaxLength(100)
                    .IsRequired();

                ent.Property(x => x.Author)
                    .HasColumnName("author")
                    .HasMaxLength(100)
                    .IsRequired();

                ent.Property(x => x.GenreId)
                    .HasColumnName("id_genre");

                ent.Property(x => x.CollateralValue)
                    .HasColumnName("collateral_value")
                    .IsRequired();

                ent.Property(x => x.RentalCost)
                    .HasColumnName("rental_cost")
                    .IsRequired();

                ent.Property(x => x.CountBook)
                    .HasColumnName("count_book")
                    .IsRequired();

                ent.HasOne(d => d.Genre)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.GenreId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Issued>(ent =>
            {
                ent.ToTable("issued");

                ent.HasKey(x => x.IssuedId).HasName("id_issued");

                ent.Property(x => x.ReaderId).HasColumnName("id_reader");

                ent.Property(x => x.BookId).HasColumnName("id_book");

                ent.Property(x => x.DateIssue)
                    .HasColumnName("date_issue")
                    .HasColumnType("date")
                    .IsRequired();

                ent.Property(x => x.DateDue)
                    .HasColumnName("date_due")
                    .HasColumnType("date")
                    .IsRequired();

                ent.HasOne(d => d.Reader)
                   .WithMany(p => p.Issueds)
                   .HasForeignKey(d => d.ReaderId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

                ent.HasOne(d => d.Book)
                   .WithMany(p => p.Issueds)
                   .HasForeignKey(d => d.BookId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}