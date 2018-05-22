using System.ComponentModel.DataAnnotations;

namespace The_Dojo_League.Models
{
    public class NinjaViewModel : BaseEntity
    {
        [Required]
        [Display(Name = "Ninja Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
        [Required]
        [MinLength (10)]
        [Display(Name = "Ninja Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Ninja's Dojo")]
        public int dojo { get; set; }
    }
}