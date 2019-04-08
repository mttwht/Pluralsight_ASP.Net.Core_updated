using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant> {
                new Restaurant {
                    Id = 1,
                    Name = "Matt's Home Cooking",
                    Location = "Home",
                    Cuisine = CuisineType.None,
                },
                new Restaurant {
                    Id = 2,
                    Name = "Cinnamon Garden",
                    Location = "Ashbourne",
                    Cuisine = CuisineType.Indian,
                },
                new Restaurant {
                    Id = 3,
                    Name = "Golden Dragon",
                    Location = "Ashbourne",
                    Cuisine = CuisineType.Chinese,
                },
                new Restaurant {
                    Id = 4,
                    Name = "Roberto's",
                    Location = "Ratoath",
                    Cuisine = CuisineType.Italian,
                },
            };
        }

        IEnumerable<Restaurant> IRestaurantData.GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
