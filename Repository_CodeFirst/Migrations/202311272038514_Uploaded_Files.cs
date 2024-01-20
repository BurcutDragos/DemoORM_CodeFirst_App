namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uploaded_Files : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [UPLOADED_FILE] (USER_ID, FILE_NAME, FILE_LOCATION, UPLOAD_DATE) VALUES (1, 'C++ programming language.pdf', 'Documents', '2023-11-12 18:12:00.000')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [UPLOADED_FILE] WHERE USER_ID = 1");
        }
    }
}
