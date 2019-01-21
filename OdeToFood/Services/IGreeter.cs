using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{

    // Dependency Injection is the automatic creation of classes and their injection into other classes through a constructor.
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }

        private IConfiguration _configuration;
        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

    }

    


}
