using Microsoft.EntityFrameworkCore;

namespace PrePics.Models;

public class PrePicsDbContext : DbContext
{
    public PrePicsDbContext(DbContextOptions<PrePicsDbContext> options) : base(options)
    {
        
    }
    public DbSet<Collection> collections { get; set; }
    public DbSet<Gallery> galleries { get; set; }
    public DbSet<GotTag> gotTags { get; set; }
    public DbSet<InCollection> inCollections { get; set; }
    public DbSet<Tag> tags { get; set; }
    public DbSet<User> users { get; set; }
}