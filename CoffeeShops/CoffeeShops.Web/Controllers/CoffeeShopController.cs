using CoffeeShops.DAL;
using CoffeeShops.Model;
using CoffeeShops.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoffeeShops.Web.Controllers
{
    //user@user.com 1Password.
    //admin@admin.com 1Password.
    public class CoffeeShopController : Controller
    {
        private CoffeeShopManagerDbContext _dbContext;

        public CoffeeShopController(CoffeeShopManagerDbContext context)
        {
            this._dbContext = context;
        }

        public IActionResult Index()
        {
            
            var coffeeShopQuery = this._dbContext.CoffeeShops.Include(c => c.City).Include(c=>c.Address).Include(mi => mi.MenuItems).AsQueryable();
            var model = coffeeShopQuery.ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult FilterAjax(CoffeeShopFilterModel filter)
        {
            filter ??= new CoffeeShopFilterModel();

            var coffeeShopQuery = this._dbContext.CoffeeShops.Include(p => p.City).Include(p => p.Address).Include(p => p.MenuItems).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.City))
                coffeeShopQuery = coffeeShopQuery.Where(p => p.City.Name.ToLower().Contains(filter.City.ToLower()));


            var model = coffeeShopQuery.ToList();
            return PartialView("_IndexList", model);
        }


        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            this.FillDropdownCityValues();
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(CoffeeShop model)
        {


            if (ModelState.IsValid)
            {
                this._dbContext.CoffeeShops.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownCityValues();
                return View();
            }
        }

        public IActionResult Details(int? id = null)
        {
            var coffeeShop = this._dbContext.CoffeeShops
                .Include(p => p.City)
                .Include(p => p.Address)
                .Include(p => p.MenuItems)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(coffeeShop);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Manage()
        {

            var coffeeShopQuery = this._dbContext.CoffeeShops.Include(c => c.City).Include(c => c.Address).AsQueryable();
            var model = coffeeShopQuery.ToList();
            return View("Manage", model);
        }

        [Authorize(Roles = "admin")]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.CoffeeShops.Include(c => c.Address).Include(c => c.City).Include(c => c.MenuItems).FirstOrDefault(c => c.ID == id);
            this.FillDropdownCityValues();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditCoffeeShop(int id)
        {
            var coffeeShop = this._dbContext.CoffeeShops.Include(c => c.Address).Include(c => c.City).Include(c => c.MenuItems).FirstOrDefault(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(coffeeShop);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownCityValues();
            return View(coffeeShop);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var model = this._dbContext.CoffeeShops.FirstOrDefault(c => c.ID == id);
            this._dbContext.CoffeeShops.Remove(model);
            this._dbContext.SaveChanges();

            var coffeeShopQuery = this._dbContext.CoffeeShops.Include(c => c.City).Include(c => c.Address).Include(mi => mi.MenuItems).AsQueryable();
            var modelView = coffeeShopQuery.ToList();
            return View("Index", modelView);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddMenuItem(MenuItem model,int id)
        {
 
            this.FillDropdownCityValues();
            if (ModelState.IsValid)
            {
                this._dbContext.MenuItems.Add(new MenuItem()
                {
                    ItemName = model.ItemName,
                    Price = model.Price,
                    CoffeeShopID = id
                });

                this._dbContext.SaveChanges();
                var coffeeShopQuery = this._dbContext.CoffeeShops.Include(c => c.City).Include(c => c.Address).Include(mi => mi.MenuItems).AsQueryable();
                var modelView = coffeeShopQuery.ToList();

                return View("Manage", modelView);
            }
            else
            {
                var coffeeShop = this._dbContext.CoffeeShops.Where(p => p.ID == id).Include(p => p.Address).Include(p => p.City).Include(p => p.MenuItems).FirstOrDefault();
                return View(nameof(Edit),coffeeShop);
            }
        }


        [HttpGet]

        public IActionResult GetMenuItems(int id)
        {


            var itemsQuery = this._dbContext.MenuItems.Where(a => a.CoffeeShopID == id).AsQueryable();



            var model = itemsQuery.ToList();
            return PartialView("_MenuItemsList", model);
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteMenuItem(int id)
        {
            var model = this._dbContext.MenuItems.FirstOrDefault(c => c.ID == id);
            this._dbContext.MenuItems.Remove(model);
            this._dbContext.SaveChanges();

            return Ok();
        }


       

        private void FillDropdownCityValues()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- Choose City -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Cities)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }
    }
}