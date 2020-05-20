using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;
namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new MvcCoffeContext(
                serviceProvider.GetRequiredService
                        <DbContextOptions<MvcCoffeContext>>()))
            {
                if(context.Coffe.Any()){
                    return;
                }
                context.Coffe.AddRange(
                    new Coffe{
                        Title = "L'OR INDONÉSIA 10 UN",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Intensity = 08,
                        Aroma = "Refinado e Aromático",
                        Type = "Cápsula",
                        Price = 7.99M,
                        HowToTake = "Espresso"
                    },
                    new Coffe{
                        Title = "L'OR GUATEMALA 10 UN",
                        ReleaseDate = DateTime.Parse("1989-13-07"),
                        Intensity = 07,
                        Aroma = "FLORAL, NOTAS DE CASTANHA, PRAZEROSO",
                        Type = "Cápsula",
                        Price = 16.99M,
                        HowToTake = "Espresso"
                    },
                    new Coffe{
                        Title = "L'OR RISTRETTO 20 UN",
                        ReleaseDate = DateTime.Parse("1967-08-07"),
                        Intensity = 11,
                        Aroma = "PODEROSO, EXPRESSIVO, IDEAL",
                        Type = "Cápsula",
                        Price = 30.50M,
                        HowToTake = "Ristretto"
                    },
                    new Coffe{
                        Title = "L'OR SATINATO 10 UN",
                        ReleaseDate = DateTime.Parse("1989-25-10"),
                        Intensity = 06,
                        Aroma = "PICANTE, REFINADO, ÚNICO",
                        Type = "Cápsula",
                        Price = 16.90M,
                        HowToTake = "Espresso"
                    },
                    new Coffe{
                        Title = "L'OR ONYX 10 UN",
                        ReleaseDate = DateTime.Parse("2002-30-08"),
                        Intensity = 12,
                        Aroma = "INTENSO, PODEROSO, MARCANTE",
                        Type = "Cápsula",
                        Price = 16.90M,
                        HowToTake = "Espresso"
                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}
