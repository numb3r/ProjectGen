namespace GlobalEventNepal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactAddresses", "Street1", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ContactAddresses", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ContactAddresses", "Country", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.ContactAddresses", "PostalCode", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactAddresses", "PostalCode", c => c.String());
            AlterColumn("dbo.ContactAddresses", "Country", c => c.String());
            AlterColumn("dbo.ContactAddresses", "City", c => c.String());
            AlterColumn("dbo.ContactAddresses", "Street1", c => c.String());
        }
    }
}
