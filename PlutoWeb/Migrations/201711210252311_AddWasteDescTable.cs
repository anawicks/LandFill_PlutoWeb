namespace PlutoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWasteDescTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblWasteDescriptionCodes",
                c => new
                    {
                        WasteDescriptionId = c.Int(nullable: false, identity: true),
                        WasteDescription = c.String(),
                        WasteDescriptionCode = c.String(),
                        WasteDescriptionInvoice = c.String(),
                    })
                .PrimaryKey(t => t.WasteDescriptionId);
            
            AlterColumn("dbo.tblConsultContacts", "ConsultantContactConsultId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblConsultContacts", "ConsultantContactConsultId", c => c.String());
            DropTable("dbo.tblWasteDescriptionCodes");
        }
    }
}
