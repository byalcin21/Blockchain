namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Balance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserSurname = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        AuthorityID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        TCNumber = c.String(maxLength: 50),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Authorities", t => t.AuthorityID, cascadeDelete: true)
                .Index(t => t.AuthorityID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Authorities",
                c => new
                    {
                        AuthorityID = c.Int(nullable: false, identity: true),
                        AuthorityLevel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorityID);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        SellID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ServerIP = c.String(maxLength: 50),
                        StorageSize = c.String(maxLength: 50),
                        SellValue = c.Single(nullable: false),
                        SellTime = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Solds",
                c => new
                    {
                        SoldID = c.Int(nullable: false, identity: true),
                        SellID = c.Int(nullable: false),
                        UserID = c.Int(),
                        PrevHash = c.String(maxLength: 256),
                        LastHash = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.SoldID)
                .ForeignKey("dbo.Sells", t => t.SellID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.SellID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BalanceValue = c.Single(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "UserID", "dbo.Users");
            DropForeignKey("dbo.Sells", "UserID", "dbo.Users");
            DropForeignKey("dbo.Solds", "UserID", "dbo.Users");
            DropForeignKey("dbo.Solds", "SellID", "dbo.Sells");
            DropForeignKey("dbo.Users", "AuthorityID", "dbo.Authorities");
            DropForeignKey("dbo.Users", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Balances", new[] { "UserID" });
            DropIndex("dbo.Solds", new[] { "UserID" });
            DropIndex("dbo.Solds", new[] { "SellID" });
            DropIndex("dbo.Sells", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "AccountID" });
            DropIndex("dbo.Users", new[] { "AuthorityID" });
            DropTable("dbo.Balances");
            DropTable("dbo.Solds");
            DropTable("dbo.Sells");
            DropTable("dbo.Authorities");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
