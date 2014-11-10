using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DevDay.Models
{
    public class RetroModel
    {
        public RetroModel()
        {
            MessagesList = new List<MessageModel>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public Guid IdRetro { get; set; }
        [Key, ForeignKey("Person")]
        public Guid IdPerson { get; set; }
        public int RetroNumber { get; set; }

        [Required]
        public virtual PersonModel Person { get; set; }
        public virtual RetroModel Retro { get; set; }
        public virtual ICollection<MessageModel> MessagesList { get; set; }
    }
}