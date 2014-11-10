using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DevDay.Models;

namespace DevDay.DAL
{
    public class DevDayContext : DbContext
    {
        public DevDayContext()
            : base("DevDayDB")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DevDayContext>());
        }

        public DbSet<RetroModel> Retros { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<MessageModel> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>()
                .HasKey(e => e.IdPerson);
            modelBuilder.Entity<PersonModel>()
                        .Property(e => e.IdPerson)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PersonModel>()
                        .HasRequired(e => e.Retro)
                        .WithRequiredDependent(s => s.Person);

            modelBuilder.Entity<MessageModel>()
                        .HasKey(e => e.IdMessage);
            modelBuilder.Entity<MessageModel>()
                        .Property(e => e.IdMessage)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //one-to-many 
            modelBuilder.Entity<MessageModel>().HasRequired<RetroModel>(s => s.Retro)
            .WithMany(s => s.MessagesList).HasForeignKey(s => s.IdRetro);

            base.OnModelCreating(modelBuilder);
        }
    }
}