using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Library.Models
{
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }
        [StringLength(1000)]
        public string MonsterName { get; set; }
        [StringLength(250)]
        public string MonsterType { get; set; }
    }
}
