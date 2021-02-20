namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Choice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OptionModels", "Choice", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OptionModels", "Choice");
        }
    }
}
