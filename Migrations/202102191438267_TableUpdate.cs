namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Options", newName: "OptionModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OptionModels", newName: "Options");
        }
    }
}
