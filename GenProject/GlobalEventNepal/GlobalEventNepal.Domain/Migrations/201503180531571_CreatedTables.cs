namespace GlobalEventNepal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "EventId", "dbo.Events");
            DropIndex("dbo.Contacts", new[] { "EventId" });
            AddColumn("dbo.Events", "Featured", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "ContactId", c => c.Guid());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(maxLength: 25));
            AlterColumn("dbo.Contacts", "EmailAddress", c => c.String(maxLength: 225));
            AlterColumn("dbo.Events", "Category", c => c.String(maxLength: 25));
            AlterColumn("dbo.Events", "Organization", c => c.String(maxLength: 25));
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String(maxLength: 100));
            CreateIndex("dbo.Events", "ContactId");
            AddForeignKey("dbo.Events", "ContactId", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Events", new[] { "ContactId" });
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Events", "Organization", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Events", "Category", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Contacts", "EmailAddress", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Events", "ContactId");
            DropColumn("dbo.Events", "Featured");
            CreateIndex("dbo.Contacts", "EventId");
            AddForeignKey("dbo.Contacts", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
