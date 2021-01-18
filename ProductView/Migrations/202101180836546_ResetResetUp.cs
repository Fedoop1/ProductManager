namespace ProductView.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetResetUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Gender_Id", c => c.Int());
            CreateIndex("dbo.Users", "Gender_Id");
            AddForeignKey("dbo.Users", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "Gender_Id" });
            DropColumn("dbo.Users", "Gender_Id");
            DropTable("dbo.Genders");
        }
    }
}
