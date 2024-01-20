namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conversion_Jobs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [CONVERSION_JOB] (FILE_ID, CONVERSION_STATUS, CONVERSION_START_TIME, CONVERSION_END_TIME, OUTPUT_FILE_LOCATION, ERROR_MESSAGE) VALUES (1, 'Completed', '2023-11-12 18:12:00.000', '2023-11-12 18:13:00.000', 'Downloads', 'Conversion made without errors!')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [CONVERSION_JOB] WHERE FILE_ID = 1");
        }
    }
}
