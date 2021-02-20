namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        QuestionId = c.Int(nullable: false),
                        QuestionModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionModels", t => t.QuestionModel_Id)
                .Index(t => t.QuestionModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "QuestionModel_Id", "dbo.QuestionModels");
            DropIndex("dbo.Options", new[] { "QuestionModel_Id" });
            DropTable("dbo.Options");
            DropTable("dbo.QuestionModels");
        }
    }
}
