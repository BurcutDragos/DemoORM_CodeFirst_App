namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conversion_Histories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [CONVERSION_HISTORY] (JOB_ID, CONVERSION_START_TIME, CONVERSION_END_TIME, INPUT_FILE_NAME, OUTPUT_FILE_NAME, USER_ID) VALUES (1, '2023-11-12 18:12:00.000', '2023-11-12 18:13:00.000', 'C++ programming language.pdf', 'C++ programming language.docx', 1)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [CONVERSION_HISTORY] WHERE JOB_ID = 1");
        }
    }
}
