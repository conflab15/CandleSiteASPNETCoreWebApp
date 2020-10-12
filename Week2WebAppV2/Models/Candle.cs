using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week2WebAppV2.Models
{
    public class Candle
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string desc { get; set; }

        [Required]
        public double price { get; set; }

        public string imageURL { get; set; }
    }
}
