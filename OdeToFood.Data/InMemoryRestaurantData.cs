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

        IEnumerable<Restaurant> IRestaurantData.GetRestaurantsByName(string name=null)
        {
            return restaurants
                .Where(r => name==null || r.Name.Contains(name, System.StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(r => r.Name);
        }
    }
}
