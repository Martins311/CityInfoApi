using CityInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo
{
    public static class CityInfoContextExtentions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            // int seed data
            var cities = new List<City>()
            {
                new City()
                {
                    Name= "New York City",
                    Description = " The one with that big park",
                    PointsOfInterest= new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = " the most visited urban park in the United States."
                        },
                        new PointOfInterest()
                        {
                            Name="Empire State Building",
                            Description="A 102-story skypcraper lacted in midtown Manhattan"
                        },
                    }
                },
                new City()
                {
                    Name = "Paris",
                    Description = "The one with big tower",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                            new PointOfInterest()
                            {
                                Name = "Eiffel Tower",
                                Description = "A wrought iron lattice tower on the Champ de Mars, named after enginner Gustavo",
                            },
                            new PointOfInterest()
                            {
                                Name = "The louvre",
                                Description = "The World's largest museum"
                            },
                    }
                },

            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
