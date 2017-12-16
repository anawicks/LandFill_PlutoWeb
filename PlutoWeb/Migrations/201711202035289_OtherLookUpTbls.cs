namespace PlutoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherLookUpTbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblConsultContacts",
                c => new
                    {
                        ConsultantContactId = c.Int(nullable: false, identity: true),
                        ConsultantContactConsultId = c.String(),
                        ConsultantContactName = c.String(),
                        ConsultantContactPhone = c.String(),
                    })
                .PrimaryKey(t => t.ConsultantContactId);
            
            CreateTable(
                "dbo.tblGeneratorContacts",
                c => new
                    {
                        GenerContactId = c.Int(nullable: false, identity: true),
                        GenerContactGenerId = c.String(),
                        GenerContactName = c.String(),
                        GenerContactPhone = c.String(),
                        GenerContactCell = c.String(),
                        GenerContactFax = c.String(),
                    })
                .PrimaryKey(t => t.GenerContactId);
            
            CreateTable(
                "dbo.tblGeneratorLocations",
                c => new
                    {
                        GenerLocationId = c.Int(nullable: false, identity: true),
                        GenerLocationGenID = c.Int(nullable: false),
                        GenerLocationLsd = c.String(),
                    })
                .PrimaryKey(t => t.GenerLocationId);
            
            CreateTable(
                "dbo.tblInterestCharges",
                c => new
                    {
                        IntAmount = c.Int(nullable: false, identity: true),
                        IntDaysOverdue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntAmount);
            
            CreateTable(
                "dbo.tblInvoicees",
                c => new
                    {
                        InvoiceeID = c.Int(nullable: false, identity: true),
                        InvoiceeName = c.String(),
                        InvoiceeAddr = c.String(),
                        InvoiceeCity = c.String(),
                        InvoiceeProv = c.String(),
                        InvoiceePostal = c.String(),
                        InvoiceePhone = c.String(),
                        InvoiceeConsultId = c.Int(nullable: false),
                        InvoiceeAttnTo = c.String(),
                        InvoiceeCareOf = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceeID);
            
            CreateTable(
                "dbo.tblSubstances",
                c => new
                    {
                        SubstanceId = c.Int(nullable: false, identity: true),
                        SubstanceName = c.String(),
                        SubstanceCode = c.String(),
                    })
                .PrimaryKey(t => t.SubstanceId);
            
            CreateTable(
                "dbo.tblTruckCompanies",
                c => new
                    {
                        TruckCompId = c.Int(nullable: false, identity: true),
                        TruckCompName = c.String(),
                        TruckCompAddr = c.String(),
                        TruckCompCity = c.String(),
                        TruckCompProv = c.String(),
                        TruckCompPostal = c.String(),
                        TruckCompPhone = c.String(),
                    })
                .PrimaryKey(t => t.TruckCompId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblTruckCompanies");
            DropTable("dbo.tblSubstances");
            DropTable("dbo.tblInvoicees");
            DropTable("dbo.tblInterestCharges");
            DropTable("dbo.tblGeneratorLocations");
            DropTable("dbo.tblGeneratorContacts");
            DropTable("dbo.tblConsultContacts");
        }
    }
}
