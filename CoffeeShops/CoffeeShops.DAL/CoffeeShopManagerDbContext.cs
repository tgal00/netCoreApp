using CoffeeShops.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShops.DAL
{
    public class CoffeeShopManagerDbContext : IdentityDbContext
    {

        public CoffeeShopManagerDbContext(DbContextOptions<CoffeeShopManagerDbContext> options) : base(options)
        {

        }


        public DbSet<City> Cities { get; set; }
        public DbSet<CoffeeShop> CoffeeShops { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IList<String> cities = new List<String>{"Zagreb",
                        "Split",
                        "Rijeka",
                        "Osijek",
                        "Zadar",
                        "Velika Gorica",
                        "Slavonski Brod",
                        "Pula",
                        "Karlovac",
                        "Sisak",
                        "Varaždin",
                        "Šibenik",
                        "Dubrovnik",
                        "Bjelovar",
                        "Kaštela",
                        "Samobor",
                        "Vinkovci",
                        "Koprivnica",
                        "Vukovar",
                        "Đakovo",
                        "Čakovec",
                        "Požega",
                        "Zaprešić",
                        "Sinj",
                        "Petrinja",
                        "Solin",
                        "Kutina",
                        "Virovitica",
                        "Križevci",
                        "Sveta Nedelja",
                        "Dugo Selo",
                        "Metković",
                        "Poreč",
                        "Našice",
                        "Sveti Ivan Zelina",
                        "Jastrebarsko",
                        "Knin",
                        "Omiš",
                        "Vrbovec",
                        "Ivanić-Grad",
                        "Rovinj",
                        "Nova Gradiška",
                        "Makarska",
                        "Ogulin",
                        "Ivanec",
                        "Slatina",
                        "Umag",
                        "Novska",
                        "Trogir",
                        "Novi Marof",
                        "Gospić",
                        "Krapina",
                        "Županja",
                        "Opatija",
                        "Labin",
                        "Daruvar",
                        "Valpovo",
                        "Pleternica",
                        "Crikvenica",
                        "Duga Resa",
                        "Benkovac",
                        "Imotski",
                        "Belišće",
                        "Kastav",
                        "Garešnica",
                        "Ploče",
                        "Beli Manastir",
                        "Otočac",
                        "Donji Miholjac",
                        "Trilj",
                        "Glina",
                        "Zabok",
                        "Vodice",
                        "Pazin",
                        "Pakrac",
                        "Ludbreg",
                        "Đurđevac",
                        "Lepoglava",
                        "Bakar",
                        "Čazma",
                        "Mali Lošinj",
                        "Rab",
                        "Ozalj",
                        "Prelog",
                        "Drniš",
                        "Senj",
                        "Ilok",
                        "Pregrada",
                        "Vrgorac",
                        "Grubišno Polje",
                        "Varaždinske Toplice",
                        "Otok",
                        "Mursko Središće",
                        "Krk",
                        "Lipik",
                        "Kutjevo",
                        "Vodnjan",
                        "Oroslavje",
                        "Buzet",
                        "Zlatar",
                        "Delnice",
                        "Donja Stubica",
                        "Korčula",
                        "Biograd na Moru",
                        "Orahovica",
                        "Novi Vinodolski",
                        "Buje",
                        "Slunj",
                        "Vrbovsko",
                        "Kraljevica",
                        "Obrovac",
                        "Novigrad",
                        "Hvar",
                        "Supetar",
                        "Pag",
                        "Čabar",
                        "Skradin",
                        "Novalja",
                        "Opuzen",
                        "Klanjec",
                        "Cres",
                        "Hrvatska Kostajnica",
                        "Nin",
                        "Stari Grad",
                        "Vrlika",
                        "Vis",
                        "Komiža"
            };
            base.OnModelCreating(modelBuilder);

            for(int i = 0; i < cities.Count; i++)
            {
                modelBuilder.Entity<City>().HasData(new City { ID = i+1, Name = cities[i] });
            }
        }
    }
}
