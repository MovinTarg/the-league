using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using The_Dojo_League.Models;

namespace The_Dojo_League.Models
{
    public class Dojo : BaseEntity
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Dojo Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [MinLength (10)]
        [Display(Name = "Dojo Information")]
        public string Info { get; set; }
        public ICollection<Ninja> ninjas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}