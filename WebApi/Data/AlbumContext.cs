using System.Net.Mime;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data;

public class AlbumContext: DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = TestExam.db");
    }
}