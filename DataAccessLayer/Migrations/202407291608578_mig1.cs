namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "Writer_WriterID" });
            RenameColumn(table: "dbo.Contents", name: "Writer_WriterID", newName: "WriterID");
            RenameColumn(table: "dbo.Headings", name: "Writer_WriterID", newName: "WriterID");
            RenameIndex(table: "dbo.Contents", name: "IX_Writer_WriterID", newName: "IX_WriterID");
            AlterColumn("dbo.Headings", "WriterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Headings", "WriterID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterID" });
            AlterColumn("dbo.Headings", "WriterID", c => c.Int());
            RenameIndex(table: "dbo.Contents", name: "IX_WriterID", newName: "IX_Writer_WriterID");
            RenameColumn(table: "dbo.Headings", name: "WriterID", newName: "Writer_WriterID");
            RenameColumn(table: "dbo.Contents", name: "WriterID", newName: "Writer_WriterID");
            CreateIndex("dbo.Headings", "Writer_WriterID");
            AddForeignKey("dbo.Headings", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
