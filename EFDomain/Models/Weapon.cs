using System.ComponentModel.DataAnnotations;

namespace EFDomain.Models
{
    public class Weapon
    {
        [Key] public int WeaponId { get; set; }

        [StringLength(1000)] public string WeaponName { get; set; }

        [StringLength(250)] public string WeaponType { get; set; }
    }
}