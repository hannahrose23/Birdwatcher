using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Birdwatcher.Models{
    public static class SeedData{
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new BirdwatcherContext(serviceProvider.GetRequiredService<DbContextOptions<BirdwatcherContext>>())){
                if (context.Bird.Any()){
                    return;
                }
                context.Bird.AddRange(
                    new Bird{
                        Name = "Northern Cardinal",
                        Color = "Red, Gray, Brown",
                        Region = "All",
                        ImageLocation = "northernCardinal.jpg"
                    },
                    new Bird{
                        Name = "Canada Goose",
                        Color = "Brown, White, Black",
                        Region = "All",
                        ImageLocation = "canadaGoose.jpg"
                    },
                    new Bird{
                        Name = "Common Loon",
                        Color = "Black, White",
                        Region = "Central, Northeast",
                        ImageLocation = "commonLoon.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}