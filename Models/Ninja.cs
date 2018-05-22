using System;
using System.ComponentModel.DataAnnotations;
using The_Dojo_League.Models;

namespace The_Dojo_League.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public Dojo dojo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}