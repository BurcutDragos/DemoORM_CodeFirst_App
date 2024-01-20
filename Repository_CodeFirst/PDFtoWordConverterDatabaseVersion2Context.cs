using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LibrarieModele;

namespace Repository_CodeFirst
{
    public class PDFtoWordConverterDatabaseVersion2Context : DbContext
    {
        public PDFtoWordConverterDatabaseVersion2Context() : base("PDFtoWordConverterDatabaseVersion2")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PDFtoWordConverterDatabaseVersion2Context, Repository_CodeFirst.Migrations.Configuration>());
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;

            // Add the following line to enable logging of SQL queries
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        // Define DbSet properties for your entities
        public DbSet<LibrarieModele.USER> USERS { get; set; }
        public DbSet<LibrarieModele.UPLOADED_FILE> UPLOADED_FILES { get; set; }
        public DbSet<LibrarieModele.CONVERSION_JOB> CONVERSION_JOBS { get; set; }
        public DbSet<LibrarieModele.CONVERSION_HISTORY> CONVERSION_HISTORIES { get; set; }
        public DbSet<LibrarieModele.USER_SETTING> USER_SETTINGS { get; set; }

        public class MyDataAccessLayer
        {
            public List<USER> GetAllUsers()
            {
                using (var context = new PDFtoWordConverterDatabaseVersion2Context())
                {
                    return context.USERS.ToList();
                }
            }

            public void PostUser(USER user)
            {
                using (var context = new PDFtoWordConverterDatabaseVersion2Context())
                {
                    context.USERS.Add(user);
                    context.SaveChanges();
                }
            }

            public void PutUser(USER user)
            {
                using (var context = new PDFtoWordConverterDatabaseVersion2Context())
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
