using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }
        
        public void OnGet()
        {
            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
            ConsoleLogger logger  = new ConsoleLogger();
            logger.LogMessage("ALEINBA TO SIE DZIEJE NAPRAWDE");
        }
    }
}