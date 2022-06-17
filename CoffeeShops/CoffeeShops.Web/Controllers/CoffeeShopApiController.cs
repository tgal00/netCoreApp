using CoffeeShops.DAL;
using CoffeeShops.Model;
using CoffeeShops.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CoffeeShops.Web.Controllers
{
    [Route("api/coffeeShop")]
    [ApiController]
    public class CoffeeShopApiController:Controller
    {
        private CoffeeShopManagerDbContext _context;

        public CoffeeShopApiController(CoffeeShopManagerDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var coffeeShops = this._context.CoffeeShops.Select(mapper).ToList();
            return Ok(coffeeShops);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {

            var coffeeShops = this._context.CoffeeShops
                .Where(c => c.ID == id)
                .Select(mapper).FirstOrDefault();

            if (coffeeShops == null)
            {
                return NotFound();
            }

            return Ok(coffeeShops);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CoffeeShop coffeeShop)
        {
            this._context.CoffeeShops.Add(new CoffeeShop()
            {
                Name = coffeeShop.Name,
                OpensAt = coffeeShop.OpensAt,
                ClosesAt = coffeeShop.ClosesAt,
                ImageUrl = coffeeShop.ImageUrl,
                MenuItems = coffeeShop.MenuItems,
                AddressID = coffeeShop.AddressID,
                CityID = coffeeShop.CityID,
            });

            this._context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var coffeeShop = this._context.CoffeeShops.First(c => c.ID == id);
            this._context.Remove(coffeeShop);
            this._context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] CoffeeShop model)
        {
            var coffeeShop = this._context.CoffeeShops.First(c => c.ID == id);

            if (model.Name != null) coffeeShop.Name = model.Name;
            if (model.OpensAt != null) coffeeShop.OpensAt = model.OpensAt;
            if (model.ClosesAt != null) coffeeShop.ClosesAt = model.ClosesAt;
            if (model.AddressID != null) coffeeShop.AddressID = model.AddressID;
            if (model.CityID != null) coffeeShop.CityID = model.CityID;
            if (model.ImageUrl != null) coffeeShop.ImageUrl = model.ImageUrl;
            if (model.MenuItems != null) coffeeShop.MenuItems = model.MenuItems;

            this._context.SaveChanges();

            return Ok();
        }


        private Expression<Func<CoffeeShop, CoffeeShop>> mapper = c => new CoffeeShop()
        {
            ID = c.ID,
            Name = c.Name,
            OpensAt = c.OpensAt,
            ClosesAt = c.ClosesAt,
            Address = c.Address,
            AddressID = c.AddressID,
            City = c.City,
            CityID = c.CityID,
            ImageUrl = c.ImageUrl,
            MenuItems = c.MenuItems


        };
    }
}