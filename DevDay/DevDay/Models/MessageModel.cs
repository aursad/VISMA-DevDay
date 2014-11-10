using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevDay.Models
{
    public class MessageModel
    {
        public MessageModel()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public Guid IdMessage { get; set; }
        [Key, ForeignKey("Person")]
        public Guid IdPerson { get; set; }
        [Key, ForeignKey("Retro")]
        public Guid IdRetro { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int MessageType { get; set; }

        public virtual PersonModel Person { get; set; }
        public virtual RetroModel Retro { get; set; }
    }
}