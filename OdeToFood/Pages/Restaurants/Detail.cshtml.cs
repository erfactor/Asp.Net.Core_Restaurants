﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class Detail : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public Detail(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        [TempData] public string Message { get; set; }

        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null) return RedirectToPage("./NotFound");

            return Page();
        }
    }
}