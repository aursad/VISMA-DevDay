using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DevDay.Model.Common;

namespace DevDay.Model
{
    [Table("Persons")]
    public class PersonEntity : Entity<int>
    {
        public string Name { get; set; }

        public virtual RetroEntity Retro { get; set; }
    }
}