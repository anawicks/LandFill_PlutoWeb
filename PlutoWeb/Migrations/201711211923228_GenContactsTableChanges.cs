namespace PlutoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenContactsTableChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblGeneratorContacts", "GenerContactGenerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblGeneratorContacts", "GenerContactGenerId", c => c.String());
        }
    }
}
