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
        public string Name { get; set; }
        public string Location { get; set; }
        public string Info { get; set; }
        public ICollection<Ninja> ninjas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}