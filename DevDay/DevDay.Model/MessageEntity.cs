using System;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Messages")]
    public class MessageEntity : Entity<int>
    {
        // Foreign key 
        public int PersonId { get; set; }
        public int RetroId { get; set; }

        //Properties
        public DateTime CreateTime { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; } 
        public bool? IsRead { get; set; }
        public Guid RetroGuid { get; set; }

        //Navigation property
        public virtual RetroEntity Retro { get; set; }
        public virtual PersonEntity Person { get; set; }
    }

    public enum MessageType
    {
        Start = 0,
        Stop = 1,
        Continious = 2
    }
}