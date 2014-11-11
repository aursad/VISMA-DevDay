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
            //Key  
            HasKey(t => t.Id);
            HasKey(t => t.IdPerson);

            //Fields  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.IdMessage).IsOptional();
            Property(t => t.IdPerson).IsRequired();

            //table  
            ToTable("Persons");

            //relationship  
            HasRequired(t => t.Retro).WithRequiredDependent(u => u.Person);
            HasRequired(t => t.Messages).WithOptional(u => u.); 
        }
    }
}