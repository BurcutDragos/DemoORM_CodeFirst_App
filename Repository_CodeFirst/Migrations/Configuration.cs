using LibrarieModele;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Repository_CodeFirst.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Repository_CodeFirst.PDFtoWordConverterDatabaseVersion2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository_CodeFirst.PDFtoWordConverterDatabaseVersion2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*context.USERS.AddOrUpdate(u => u.USERNAME,
                    new USER { USERNAME = "Ion_Ionescu", PASSWORD = "ionionescu", EMAIL = "ion.ionescu@yahoo.com", REGISTRATION_DATE = new DateTime(2023, 11, 12, 18, 0, 0) });*/
            /*context.USER_SETTINGS.AddOrUpdate(u => u.USER_ID,
                    new USER_SETTING { USER_ID = 2, SETTING_NAME = "Default Conversion Format", SETTING_VALUE = ".DOCX" });*/
            /*context.UPLOADED_FILES.AddOrUpdate(u => u.USER_ID,
                new UPLOADED_FILE { USER_ID = 2, FILE_NAME = "C programming language.pdf", FILE_LOCATION = "Documents", UPLOAD_DATE = new DateTime(2023, 11, 12, 18, 10, 0) });*/
            /*context.CONVERSION_JOBS.AddOrUpdate(u => u.FILE_ID,
                new CONVERSION_JOB { FILE_ID = 2, CONVERSION_STATUS = "Completed", CONVERSION_START_TIME = new DateTime(2023, 11, 12, 18, 10, 0), CONVERSION_END_TIME = new DateTime(2023, 11, 12, 18, 11, 0), OUTPUT_FILE_LOCATION = "Downloads", ERROR_MESSAGE = "Conversion made without errors!" });*/
            /*context.CONVERSION_HISTORIES.AddOrUpdate(u => u.JOB_ID,
                new CONVERSION_HISTORY { JOB_ID = 2, CONVERSION_START_TIME = new DateTime(2023, 11, 12, 18, 10, 0), CONVERSION_END_TIME = new DateTime(2023, 11, 12, 18, 11, 0), INPUT_FILE_NAME = "C programming language.pdf", OUTPUT_FILE_NAME = "C programming language.docx", USER_ID = 2});*/
        }
    }
}
