using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Common.Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string ArmorName { get; set; }
        [StringLength(250)]
        public string ArmorType { get; set; }
    }
}
