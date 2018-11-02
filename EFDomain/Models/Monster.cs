using System.ComponentModel.DataAnnotations;

namespace EFDomain.Models
{
    public class Monster
    {
        [Key] public int MonsterId { get; set; }

        [StringLength(1000)] public string MonsterName { get; set; }

        [StringLength(250)] public string MonsterType { get; set; }
    }
}