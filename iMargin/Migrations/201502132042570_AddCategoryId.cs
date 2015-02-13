namespace iMargin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Notes", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Notes", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Category", c => c.String());
            DropColumn("dbo.Notes", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
