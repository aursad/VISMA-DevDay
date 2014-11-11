using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Retros")]
    public class RetroEntity : Entity<int>
    {
        public RetroEntity()
        {
            Messages = new List<MessageEntity>();
        }
        // Foreign key 
        public int PersonId { get; set; }

        //Properties
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public RetroTypeEnum RetroType { get; set; }

        //Navigation property
        public virtual PersonEntity Person { get; set; }
        public virtual ICollection<MessageEntity> Messages { get; set; }
    }

    public enum RetroTypeEnum
    {
        WriteMode = 0,
        ReadMode = 1
    }
}