using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDomain.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string ItemName { get; set; }
        [StringLength(250)]
        public string ItemType { get; set; }
    }
}
