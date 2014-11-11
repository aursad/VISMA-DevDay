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
            //Key  
            HasKey(t => t.Id);
            HasKey(t => t.IdRetro);

            //Fields  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.IdRetro).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.IdPerson).IsOptional();

            //table  
            ToTable("Retros");  
        }
    }
}