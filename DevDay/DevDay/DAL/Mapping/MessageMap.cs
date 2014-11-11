using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DevDay.Model;

namespace DevDay.DAL.Mapping
{
    public class MessageMap : EntityTypeConfiguration<MessageEntity>  
    {
        public MessageMap()
        {
            // PK
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PersonId).IsRequired();
            Property(t => t.RetroId).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.Message).IsRequired().HasMaxLength(255);
            Property(t => t.IsRead).IsOptional();

            // Table and column Mappings
            ToTable("Messages");
            Property(t => t.Id).HasColumnName("ID");


            // Relationships
            HasRequired(x => x.Retro).WithMany(x => x.Messages).HasForeignKey(x => x.RetroId);
            HasRequired(t => t.Person).WithMany().HasForeignKey(d => d.PersonId).WillCascadeOnDelete(false);
        }
    }
}