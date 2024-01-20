namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CONVERSION_JOB", "CONVERSION_MESSAGE", c => c.String());
            AddColumn("dbo.USER", "PHONE", c => c.String());
            AddColumn("dbo.USER", "LAST_LOGIN_DATE", c => c.DateTime(nullable: false));
            DropColumn("dbo.CONVERSION_JOB", "ERROR_MESSAGE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CONVERSION_JOB", "ERROR_MESSAGE", c => c.String());
            DropColumn("dbo.USER", "LAST_LOGIN_DATE");
            DropColumn("dbo.USER", "PHONE");
            DropColumn("dbo.CONVERSION_JOB", "CONVERSION_MESSAGE");
        }
    }
}
