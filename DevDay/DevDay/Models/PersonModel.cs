using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevDay.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public Guid IdPerson { get; set; }
        [Key, ForeignKey("Retro")]
        public Guid IdRetro { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual RetroModel Retro { get; set; }
    }
}