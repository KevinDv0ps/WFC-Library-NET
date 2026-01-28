namespace WcfLibrary.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreDeLaMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        second_name = c.String(),
                        first_lastname = c.String(),
                        second_lastname = c.String(),
                        nacionality = c.String(),
                        birth_date = c.DateTime(nullable: false),
                        death_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        published_date = c.DateTime(nullable: false),
                        is_available = c.Boolean(nullable: false),
                        Loan_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Loans", t => t.Loan_id)
                .Index(t => t.Loan_id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        genre_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bookId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        loan_date = c.DateTime(nullable: false),
                        due_date = c.DateTime(nullable: false),
                        return_date = c.DateTime(),
                        is_return = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.bookId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.bookId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        second_name = c.String(),
                        first_lastname = c.String(),
                        second_lastname = c.String(),
                        email = c.String(),
                        phone_number = c.String(),
                        register_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.BookId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.BookId })
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "Loan_id", "dbo.Loans");
            DropForeignKey("dbo.Loans", "userId", "dbo.Users");
            DropForeignKey("dbo.Loans", "bookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "GenreId", "dbo.Genres");
            DropIndex("dbo.AuthorBooks", new[] { "BookId" });
            DropIndex("dbo.AuthorBooks", new[] { "AuthorId" });
            DropIndex("dbo.GenreBooks", new[] { "BookId" });
            DropIndex("dbo.GenreBooks", new[] { "GenreId" });
            DropIndex("dbo.Loans", new[] { "userId" });
            DropIndex("dbo.Loans", new[] { "bookId" });
            DropIndex("dbo.Books", new[] { "Loan_id" });
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.GenreBooks");
            DropTable("dbo.Users");
            DropTable("dbo.Loans");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
