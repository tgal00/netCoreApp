using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Model
{
    public class MenuItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]

        public float Price { get; set; }

        [ForeignKey(nameof(CoffeeShop))]
        public int? CoffeeShopID { get; set; }
        public CoffeeShop? CoffeeShop { get; set; }


    }
}
