using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Model
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }


    }
}
