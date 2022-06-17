using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Model
{
    public class CoffeeShop
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime OpensAt { get; set; }
        [Required]
        public DateTime ClosesAt { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressID { get; set; }
        public Address? Address { get; set; }

        [ForeignKey(nameof(City))]
        public int CityID { get; set; }
        public City? City { get; set; }

        public virtual ICollection<MenuItem>? MenuItems { get; set; }

    }
}
