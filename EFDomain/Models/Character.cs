using System.ComponentModel.DataAnnotations;

namespace EFDomain.Models
{
    public class Character
    {
        [Key] public int Id { get; set; }

        [StringLength(1000)] public string CharacterName { get; set; }

        [StringLength(250)] public string CharacterType { get; set; }
    }
}