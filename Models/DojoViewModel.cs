using System.ComponentModel.DataAnnotations;

namespace The_Dojo_League.Models
{
    public class DojoViewModel : BaseEntity
    {
        [Required]
        [Display(Name = "Dojo Name")]
        public string Name { get; set; }
        [Required]
        [MinLength (10)]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [MinLength (10)]
        [Display(Name = "Dojo Information")]
        public string Info { get; set; }
    }
}