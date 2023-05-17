namespace Work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Contact", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Contact");
        }
    }
}
