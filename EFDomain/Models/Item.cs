using System.ComponentModel.DataAnnotations;

namespace EFDomain.Models
{
    public class Item
    {
        [Key] public int Id { get; set; }

        [StringLength(1000)] public string ItemName { get; set; }

        [StringLength(250)] public string ItemType { get; set; }
    }
}