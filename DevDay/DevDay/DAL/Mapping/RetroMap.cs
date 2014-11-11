using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DevDay.Model;

namespace DevDay.DAL.Mapping
{
    public class RetroMap : EntityTypeConfiguration<RetroEntity>  
    {
        public RetroMap()
        {
            // PK
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PersonId).IsRequired();
            Property(t => t.Name).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.RetroType).IsRequired();

            // Table and column Mappings
            ToTable("Retros");
            Property(t => t.Id).HasColumnName("ID");


            // Relationships
            HasRequired(t => t.Person).WithMany().HasForeignKey(d => d.PersonId).WillCascadeOnDelete(false);
        }
    }
}