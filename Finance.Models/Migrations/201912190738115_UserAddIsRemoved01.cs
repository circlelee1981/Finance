namespace Finance.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddIsRemoved01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsRemoved");
        }
    }
}
