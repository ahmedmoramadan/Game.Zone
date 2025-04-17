using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace APPPlay.Data
{
    public class AppDbContext : IdentityDbContext<Appuser>
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet <Categorie> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameDevice>().HasKey(x => new { x.DeviceId, x.GameId });

            modelBuilder.Entity<Categorie>().HasData(new Categorie[]
            {
                new Categorie {Id= 1 , Name= "Sports" },
                new Categorie {Id= 2 , Name= "Action" },
                new Categorie {Id= 3 , Name= "Adventure" },
                new Categorie {Id= 4 , Name= "Racing" },
                new Categorie {Id= 5 , Name= "Fighting" },
                new Categorie {Id= 6 , Name= "Film" }
            });
            modelBuilder.Entity<Device>().HasData(new Device[]
            {
                new Device {Id= 1 , Name= "Playstation" , Icon = "bi bi-playstation"},
                new Device {Id= 2 , Name= "xbox"        , Icon = "bi bi-xbox"       },
                new Device {Id= 3 , Name= "Nintendo"    , Icon = "bi bi-nintendo"   },
                new Device {Id= 4 , Name= "PC"          , Icon = "bi bi-pc-daisplay"}

            });
        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
    }
}
