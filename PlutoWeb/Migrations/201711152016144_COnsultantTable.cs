namespace PlutoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class COnsultantTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblConsultants",
                c => new
                    {
                        ConsultantId = c.Int(nullable: false, identity: true),
                        ConsultantName = c.String(),
                        ConsultantAddr = c.String(),
                        ConsultantCity = c.String(),
                        ConsultantProv = c.String(),
                        ConsultantPostal = c.String(),
                        ConsultantPhone = c.String(),
                        ConsultantNotes = c.String(),
                    })
                .PrimaryKey(t => t.ConsultantId);
            
            CreateTable(
                "dbo.tblGenerators",
                c => new
                    {
                        GeneratorId = c.Int(nullable: false, identity: true),
                        GeneratorName = c.String(),
                        GenaratorAddr = c.String(),
                        GeneratorCity = c.String(),
                        GeneratorProv = c.String(),
                        GeneratorPostal = c.String(),
                        GeneratorPhone = c.String(),
                        GeneratorComments = c.String(),
                        GeneratorExcldInterest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GeneratorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblGenerators");
            DropTable("dbo.tblConsultants");
        }
    }
}
