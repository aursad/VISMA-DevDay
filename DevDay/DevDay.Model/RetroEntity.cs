using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Retros")]
    public class RetroEntity : Entity<int>
    {
        public RetroEntity()
        {
            MessagesList = new List<MessageEntity>();
        }

        public Guid IdRetro { get; set; }
        public Guid? IdPerson { get; set; }

        public PersonEntity Person { get; set; }
        public ICollection<MessageEntity> MessagesList { get; set; }
    }
}