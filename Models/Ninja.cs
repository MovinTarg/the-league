using System;
using System.ComponentModel.DataAnnotations;
using The_Dojo_League.Models;

namespace The_Dojo_League.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ninja Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Ninja's Dojo")]
        public int dojo_id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Dojo ElDojo { get; set; }
    }
}