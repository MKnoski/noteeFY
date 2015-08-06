namespace NoteeFY.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Notes", "User_UserID", c => c.Int());
            CreateIndex("dbo.Notes", "User_UserID");
            AddForeignKey("dbo.Notes", "User_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.TaskItems", "isEdit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskItems", "isEdit", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Notes", "User_UserID", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_UserID" });
            DropColumn("dbo.Notes", "User_UserID");
            DropTable("dbo.Users");
        }
    }
}
