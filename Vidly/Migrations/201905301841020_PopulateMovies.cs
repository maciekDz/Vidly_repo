namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (MovieName,GenreId,RelaseDate,DateAdded,NumberInStock) VALUES ('Shrek',1,'2000-07-23','2010-10-01',1)");
            Sql("INSERT INTO Movies (MovieName,GenreId,RelaseDate,DateAdded,NumberInStock) VALUES ('Girl, Interrupted',2,'1999-09-02','2010-10-02',2)");
            Sql("INSERT INTO Movies (MovieName,GenreId,RelaseDate,DateAdded,NumberInStock) VALUES ('Rambo: First Blood',3,'1985-01-13','2010-10-03',3)");
            Sql("INSERT INTO Movies (MovieName,GenreId,RelaseDate,DateAdded,NumberInStock) VALUES ('Alien',4,'1979-03-01','2010-10-04',4)");
            Sql("INSERT INTO Movies (MovieName,GenreId,RelaseDate,DateAdded,NumberInStock) VALUES ('Planet Earth',5,'2006-1-06','2010-10-05',5)");
        }
        
        public override void Down()
        {
        }
    }
}
