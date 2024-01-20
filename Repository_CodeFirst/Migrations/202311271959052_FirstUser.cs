namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [USER] (USERNAME, PASSWORD, EMAIL, REGISTRATION_DATE) VALUES ('Ion_Vasilescu-test', 'hashedpassword3', 'ion.vasilescu@yahoo.com', '2023-11-12 18:00:00.000')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [USER] WHERE USERNAME = 'Ion_Vasilescu'");
        }
    }
}
