namespace QuizOPoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        DateCreated = c.DateTime(nullable: false),
                        OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.PollCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PollAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollAnswerId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PollAnswers", t => t.PollAnswerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PollAnswerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ScoreValue = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Poll_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .Index(t => t.QuizId)
                .Index(t => t.UserId)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        DateCreated = c.DateTime(nullable: false),
                        OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.QuizCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 256),
                        Answers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answers_Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId)
                .Index(t => t.Answers_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 256),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PollCategoryPolls",
                c => new
                    {
                        PollCategory_Id = c.Int(nullable: false),
                        Poll_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PollCategory_Id, t.Poll_Id })
                .ForeignKey("dbo.PollCategories", t => t.PollCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Polls", t => t.Poll_Id, cascadeDelete: true)
                .Index(t => t.PollCategory_Id)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.QuizCategoryQuizs",
                c => new
                    {
                        QuizCategory_Id = c.Int(nullable: false),
                        Quiz_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizCategory_Id, t.Quiz_Id })
                .ForeignKey("dbo.QuizCategories", t => t.QuizCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id, cascadeDelete: true)
                .Index(t => t.QuizCategory_Id)
                .Index(t => t.Quiz_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Poll_Id", "dbo.Polls");
            DropForeignKey("dbo.Scores", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Scores", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Questions", "Answers_Id", "dbo.Answers");
            DropForeignKey("dbo.Quizs", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuizCategoryQuizs", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.QuizCategoryQuizs", "QuizCategory_Id", "dbo.QuizCategories");
            DropForeignKey("dbo.PollAnswers", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Votes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "PollAnswerId", "dbo.PollAnswers");
            DropForeignKey("dbo.Polls", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PollCategoryPolls", "Poll_Id", "dbo.Polls");
            DropForeignKey("dbo.PollCategoryPolls", "PollCategory_Id", "dbo.PollCategories");
            DropIndex("dbo.QuizCategoryQuizs", new[] { "Quiz_Id" });
            DropIndex("dbo.QuizCategoryQuizs", new[] { "QuizCategory_Id" });
            DropIndex("dbo.PollCategoryPolls", new[] { "Poll_Id" });
            DropIndex("dbo.PollCategoryPolls", new[] { "PollCategory_Id" });
            DropIndex("dbo.Questions", new[] { "Answers_Id" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Quizs", new[] { "OwnerId" });
            DropIndex("dbo.Scores", new[] { "Poll_Id" });
            DropIndex("dbo.Scores", new[] { "UserId" });
            DropIndex("dbo.Scores", new[] { "QuizId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.Votes", new[] { "PollAnswerId" });
            DropIndex("dbo.PollAnswers", new[] { "PollId" });
            DropIndex("dbo.Polls", new[] { "OwnerId" });
            DropTable("dbo.QuizCategoryQuizs");
            DropTable("dbo.PollCategoryPolls");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.QuizCategories");
            DropTable("dbo.Quizs");
            DropTable("dbo.Scores");
            DropTable("dbo.Votes");
            DropTable("dbo.PollAnswers");
            DropTable("dbo.PollCategories");
            DropTable("dbo.Polls");
        }
    }
}
