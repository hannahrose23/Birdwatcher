using Microsoft.EntityFrameworkCore;

namespace Birdwatcher.Models{
    public class BirdwatcherContext : DbContext{
        public BirdwatcherContext (DbContextOptions<BirdwatcherContext> options) : base(options){}
        public DbSet<Birdwatcher.Models.Bird> Bird {get; set;}
        public DbSet<Birdwatcher.Models.User> User {get; set; }
    }
}