using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        Restaurant IRestaurantData.GetById(int id)
            => restaurants.SingleOrDefault(r => r.Id == id);

        IEnumerable<Restaurant> IRestaurantData.GetRestaurantsByName(string name = null)
            => restaurants
                .Where(r => name == null || r.Name.Contains(name, System.StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(r => r.Name);

        Restaurant IRestaurantData.Update(Restaurant restaurant)
        {
            var existing = restaurants
                .SingleOrDefault(r => r.Id == restaurant.Id);

            if(existing != null) {
                existing.Name = restaurant.Name;
                existing.Location = restaurant.Location;
                existing.Cuisine = restaurant.Cuisine;
            }

            return existing;
        }

        int IRestaurantData.Commit()
            => 0;
    }
}
