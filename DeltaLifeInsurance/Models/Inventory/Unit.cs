using System.ComponentModel.DataAnnotations;

namespace DeltaLifeInsurance.Models.Inventory
{
    public class Unit:Base
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }

    }
}
