using RestaurantAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Net;


namespace RestaurantAPI.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantContext _context;
        public RestaurantController(RestaurantContext context)
        {
            _context = context;
            MockData();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantItem>>> GetRestaurants()
        {
                if (_context.RestaurantItems == null)
                return NotFound();

            try
            {
                if (_context.OpenHoursItems != null)
                    AddOpenHoursToRestaurant(null);

                return await _context.RestaurantItems.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<RestaurantItem>> GetRestaurantOfTheDay()
        {
            if (_context.RestaurantItems == null)
                return NotFound();

            try
            {
                List<int> idList = _context.RestaurantItems.Select(_ => _.Id).ToList();
                Random random = new Random();
                int randomIdIndex = random.Next(idList.Count());
                if (_context.UsedRandomRestaurantItems != null)
                {
                    while (_context.UsedRandomRestaurantItems.Any(random => random.Id == idList[randomIdIndex]))
                    {
                        randomIdIndex = random.Next(idList.Count());
                    }
                    if (_context.UsedRandomRestaurantItems.Count() > 2)
                    {
                        _context.UsedRandomRestaurantItems.RemoveRange(_context.UsedRandomRestaurantItems);
                        _context.SaveChanges();
                    }
                    _context.UsedRandomRestaurantItems.Add(new UsedRandomRestaurantItem { Id = idList[randomIdIndex] });
                    _context.SaveChanges();
                }
                if (_context.OpenHoursItems != null)
                    AddOpenHoursToRestaurant(idList[randomIdIndex]);

                return await _context.RestaurantItems.Where(_ => _.Id == idList[randomIdIndex]).SingleAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantItem>> AddRestaurant(string food, string name, string address, string city, [FromQuery] DayOfWeek[] dayNumber, string open, string close)
        {
            try
            {
                _context.RestaurantItems.Add(new RestaurantItem { Food = food, Name = name, Address = address, City = city });
                await _context.SaveChangesAsync();
                foreach (var day in dayNumber)
                {
                    OpenHoursItem openHours = new OpenHoursItem();
                    _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = _context.RestaurantItems.Last().Id, Day = day, Open = open, Close = close });

                }
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(AddRestaurant), new RestaurantItem { Food = food, Name = name });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPost]
        public async Task<ActionResult<OpenHoursItem>> AddOpenHours(int restaurantid, [FromQuery] DayOfWeek[] dayNumber, string open, string close)
        {
            try
            {

                if (!_context.OpenHoursItems.Any(f => f.RestaurantId == restaurantid))
                {

                    foreach (var day in dayNumber)
                    {
                        OpenHoursItem openHours = new OpenHoursItem();
                        _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = restaurantid, Day = day, Open = open, Close = close });

                    }
                    //_context.RestaurantItems.Where(restaurant => restaurant.Id == restaurantid).Select(openHours => openHours.OpenHours.Add());
                }
                else
                {
                    foreach (var day in dayNumber)
                    {
                        await _context.OpenHoursItems.Where(f => f.RestaurantId == restaurantid && f.Day == day).ForEachAsync(selectedDay =>
                        {
                            selectedDay.Open = open;
                            selectedDay.Close = close;
                        });

                    }
                }
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(AddOpenHours), new OpenHoursItem { RestaurantId = restaurantid });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        private void MockData()
        {
            if (!_context.RestaurantItems.Any())
            {
                _context.RestaurantItems.Add(new RestaurantItem { Food = "Vietnamesiskt", Name = "Vi Viet", Address = "Erik Dahlbergsgatan 20", City = "Göteborg" });
                _context.RestaurantItems.Add(new RestaurantItem { Food = "Hamburgare", Name = "2112", Address = "Magasinsgatan 5", City = "Göteborg" });
                _context.RestaurantItems.Add(new RestaurantItem { Food = "Pizza", Name = "Pizza Hut", Address = "Sjukhusgatan 12", City = "Jönköping" });
                _context.RestaurantItems.Add(new RestaurantItem { Food = "Italienskt", Name = "Pasta Plus", Address = "Södra Vägen 2", City = "Göteborg" });

                _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = 1, Day = (DayOfWeek)1, Open = "11", Close = "21" });
                _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = 1, Day = (DayOfWeek)2, Open = "11", Close = "21" });
                _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = 1, Day = (DayOfWeek)3, Open = "11", Close = "21" });
                _context.OpenHoursItems.Add(new OpenHoursItem { RestaurantId = 1, Day = (DayOfWeek)4, Open = "11", Close = "21" });

            }
            _context.SaveChanges();
        }
        private void AddOpenHoursToRestaurant(int? id)
        {
            if (id == null)
            {
                foreach (var restaurant in _context.RestaurantItems)
                {
                    restaurant.OpenHours = new List<OpenHoursItem>();
                    foreach (var openHours in _context.OpenHoursItems.Where(item => item.RestaurantId == restaurant.Id))
                    {
                        restaurant.OpenHours.Add(new OpenHoursItem { RestaurantId = openHours.RestaurantId, Day = openHours.Day, Open = openHours.Open, Close = openHours.Close });
                    }
                }
            }
            else
            {
                foreach (var openHours in _context.OpenHoursItems.Where(item => item.RestaurantId == id))
                {
                    _context.RestaurantItems.Where(item => item.Id == id).First()?.OpenHours.Add(new OpenHoursItem { RestaurantId = openHours.RestaurantId, Day = openHours.Day, Open = openHours.Open, Close = openHours.Close });
                }
            }
        }


    }
}