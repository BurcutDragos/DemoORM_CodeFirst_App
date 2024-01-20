namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users_Settings : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [USER_SETTING] (USER_ID, SETTING_NAME, SETTING_VALUE) VALUES (1, 'Default Conversion Format', '.DOCX')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [USER_SETTING] WHERE USER_ID = 1");
        }
    }
}
