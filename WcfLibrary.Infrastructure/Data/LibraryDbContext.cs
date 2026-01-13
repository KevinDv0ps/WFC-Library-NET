using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Infrastructure.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("name=LibraryDbConnection")
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1 Loan -> 1 Book (Book puede NO tener Loan)
            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.book)
                .WithOptional(b => b.Loan)
                .Map(m => m.MapKey("id_book"));

            // N Loan -> 1 User
            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.user)
                .WithMany(u => u.Loans)
                .Map(m => m.MapKey("id_user"));

            // N Author -> N Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .Map(m =>
                {
                    m.ToTable("AuthorBooks");
                    m.MapLeftKey("id_author");
                    m.MapRightKey("id_book");
                });

            // N Genre -> N Book
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .Map(m =>
                {
                    m.ToTable("GenreBooks");
                    m.MapLeftKey("id_genre");
                    m.MapRightKey("id_book");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
