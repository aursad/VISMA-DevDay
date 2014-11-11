using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DevDay.Model;

namespace DevDay.DAL.Mapping
{
    public class MessageMap : EntityTypeConfiguration<MessageEntity>  
    {
        public MessageMap()
        {
            //Key  
            HasKey(t => t.Id);

            //Fields  
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Message).IsRequired().HasMaxLength(255);
            Property(t => t.MessageType).IsOptional();
            Property(t => t.IdPerson).IsRequired();
            Property(t => t.IdMessage).IsOptional();
            Property(t => t.Date);

            //table  
            ToTable("Messages");

            //relationship  
            HasRequired(t => t.Retro).WithMany(c => c.MessagesList).HasForeignKey
                   (t => t.IdRetro).WillCascadeOnDelete(false);
            HasRequired(t => t.Person).WithMany(c => c.Messages).HasForeignKey
                   (t => t.IdPerson).WillCascadeOnDelete(false);  
        }
    }
}