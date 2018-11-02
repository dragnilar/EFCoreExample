using System.ComponentModel.DataAnnotations;

namespace EFDomain.Models
{
    public class Armor
    {
        [Key] public int Id { get; set; }

        [StringLength(1000)] public string ArmorName { get; set; }

        [StringLength(250)] public string ArmorType { get; set; }
    }
}