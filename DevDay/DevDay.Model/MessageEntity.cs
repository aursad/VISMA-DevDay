using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Messages")]
    public class MessageEntity : Entity<int>
    {
        public MessageEntity()
        {

        }

        public Guid IdMessage { get; set; }
        public Guid IdPerson { get; set; }
        public Guid IdRetro { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int MessageType { get; set; }

        public virtual PersonEntity Person { get; set; }
        public virtual RetroEntity Retro { get; set; }
    }
}