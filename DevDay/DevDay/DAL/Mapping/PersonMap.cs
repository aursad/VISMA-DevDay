using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DevDay.Model;

namespace DevDay.DAL.Mapping
{
    public class PersonMap : EntityTypeConfiguration<PersonEntity>  
    {
        public PersonMap()
        {
            // PK
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(55);

            // Table and column Mappings
            ToTable("Persons");
            Property(t => t.Id).HasColumnName("ID");
        }
    }
}