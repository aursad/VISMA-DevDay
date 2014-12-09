using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using DevDay.Infrastructure;
using DevDay.Model;

namespace DevDay.DAL
{
    public class DevDayContext : DbContext
    {
        public DevDayContext()
            : base("DevDayContext")
        {
            Configuration.ProxyCreationEnabled = false; 
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DevDayContext>());
        }

        public DbSet<RetroEntity> Retros { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}