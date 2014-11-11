using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Persons")]
    public class PersonEntity : Entity<int>
    {
        public PersonEntity()
        {
            
        }

        public Guid IdPerson { get; set; }
        public Guid IdRetro { get; set; }
        public Guid? IdMessage { get; set; }
        public string Name { get; set; }

        public virtual RetroEntity Retro { get; set; }
        public ICollection<MessageEntity> Messages { get; set; }
    }
}