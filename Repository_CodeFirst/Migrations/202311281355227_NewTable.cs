namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USER_ACTIVITY_LOG",
                c => new
                {
                    LOG_ID = c.Int(nullable: false, identity: true),
                    USER_ID = c.Int(nullable: false),
                    ACTIVITY_TYPE = c.String(),
                    ACTIVITY_DATE = c.DateTime(nullable: false),
                    DETAILS = c.String(),
                })
                .PrimaryKey(t => t.LOG_ID)
                .ForeignKey("dbo.USER", t => t.USER_ID, cascadeDelete: false)
                .Index(t => t.USER_ID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER_ACTIVITY_LOG", "USER_ID", "dbo.USER");
            DropIndex("dbo.USER_ACTIVITY_LOG", new[] { "USER_ID" });
            DropTable("dbo.USER_ACTIVITY_LOG");
        }
    }
}
