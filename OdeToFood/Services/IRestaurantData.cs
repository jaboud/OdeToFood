using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);

        void Add(Restaurant restaurant);

        int Commit();
    }

    public class SQLRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDBContext _context;

        public SQLRestaurantData(OdeToFoodDBContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants?.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            _context.Add(restaurant);
            _context.SaveChanges();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
               new Restaurant {Id = 1, Name = "Justin's Pizza Place"},
               new Restaurant {Id = 2, Name = "Pizza Hut"},
               new Restaurant {Id = 3, Name = "Dominos"}
            };
        }

        public int Commit()
        {
            return 0;
        }


        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }
        
        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        static List<Restaurant> _restaurants;
    }
}
