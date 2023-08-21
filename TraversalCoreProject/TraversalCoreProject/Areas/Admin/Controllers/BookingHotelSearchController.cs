using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2023-09-10&departure_date=2023-09-11&guest_qty=1&dest_ids=-3712125&room_qty=1&search_type=city&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=en-us&travel_purpose=leisure"),
                Headers =
    {
        { "X-RapidAPI-Key", "47bb07bd8amsha87e4eed96d29a9p153ff0jsn000fc9f9555d" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", ""); // Burası ************* Farklı bir değer geldiğinde onu görme *******************
                var values = JsonConvert.DeserializeObject<BookingSearchModel>(bodyReplace);

                return View(values.result);
            }


        }
        [HttpGet]
        public IActionResult GetCityDestID()
        {

            return View();
        }


        [HttpPost]
        public async Task< IActionResult> GetCityDestID(string p)
        {


        
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/locations/auto-complete?text={p}"),
                Headers =
    {
        { "X-RapidAPI-Key", "47bb07bd8amsha87e4eed96d29a9p153ff0jsn000fc9f9555d" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();            }

        }






    }





}

