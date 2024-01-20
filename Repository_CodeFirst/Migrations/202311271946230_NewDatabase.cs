namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CONVERSION_HISTORY",
                c => new
                    {
                        HISTORY_ID = c.Int(nullable: false, identity: true),
                        JOB_ID = c.Int(nullable: false),
                        CONVERSION_START_TIME = c.DateTime(nullable: false),
                        CONVERSION_END_TIME = c.DateTime(nullable: false),
                        INPUT_FILE_NAME = c.String(),
                        OUTPUT_FILE_NAME = c.String(),
                        USER_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HISTORY_ID)
                .ForeignKey("dbo.CONVERSION_JOB", t => t.JOB_ID, cascadeDelete: false)
                .ForeignKey("dbo.USER", t => t.USER_ID, cascadeDelete: false)
                .Index(t => t.JOB_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.CONVERSION_JOB",
                c => new
                    {
                        JOB_ID = c.Int(nullable: false, identity: true),
                        FILE_ID = c.Int(nullable: false),
                        CONVERSION_STATUS = c.String(),
                        CONVERSION_START_TIME = c.DateTime(),
                        CONVERSION_END_TIME = c.DateTime(),
                        OUTPUT_FILE_LOCATION = c.String(),
                        ERROR_MESSAGE = c.String(),
                    })
                .PrimaryKey(t => t.JOB_ID)
                .ForeignKey("dbo.UPLOADED_FILE", t => t.FILE_ID, cascadeDelete: false)
                .Index(t => t.FILE_ID);
            
            CreateTable(
                "dbo.UPLOADED_FILE",
                c => new
                    {
                        FILE_ID = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        FILE_NAME = c.String(),
                        FILE_LOCATION = c.String(),
                        UPLOAD_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FILE_ID)
                .ForeignKey("dbo.USER", t => t.USER_ID, cascadeDelete: false)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        USER_ID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(),
                        PASSWORD = c.String(),
                        EMAIL = c.String(),
                        REGISTRATION_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.USER_ID);
            
            CreateTable(
                "dbo.USER_SETTING",
                c => new
                    {
                        SETTING_ID = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        SETTING_NAME = c.String(),
                        SETTING_VALUE = c.String(),
                    })
                .PrimaryKey(t => t.SETTING_ID)
                .ForeignKey("dbo.USER", t => t.USER_ID, cascadeDelete: false)
                .Index(t => t.USER_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CONVERSION_HISTORY", "USER_ID", "dbo.USER");
            DropForeignKey("dbo.USER_SETTING", "USER_ID", "dbo.USER");
            DropForeignKey("dbo.UPLOADED_FILE", "USER_ID", "dbo.USER");
            DropForeignKey("dbo.CONVERSION_JOB", "FILE_ID", "dbo.UPLOADED_FILE");
            DropForeignKey("dbo.CONVERSION_HISTORY", "JOB_ID", "dbo.CONVERSION_JOB");
            DropIndex("dbo.USER_SETTING", new[] { "USER_ID" });
            DropIndex("dbo.UPLOADED_FILE", new[] { "USER_ID" });
            DropIndex("dbo.CONVERSION_JOB", new[] { "FILE_ID" });
            DropIndex("dbo.CONVERSION_HISTORY", new[] { "USER_ID" });
            DropIndex("dbo.CONVERSION_HISTORY", new[] { "JOB_ID" });
            DropTable("dbo.USER_SETTING");
            DropTable("dbo.USER");
            DropTable("dbo.UPLOADED_FILE");
            DropTable("dbo.CONVERSION_JOB");
            DropTable("dbo.CONVERSION_HISTORY");
        }
    }
}
