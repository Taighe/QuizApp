namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipUpate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Options", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Options", "QuestionId", c => c.Int(nullable: false));
        }
    }
}
