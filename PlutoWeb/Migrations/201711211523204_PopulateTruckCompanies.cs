namespace PlutoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTruckCompanies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[tblTruckCompanies] ON");
            Sql("INSERT [dbo].[tblTruckCompanies] ([TruckCompId], [TruckCompName], [TruckCompAddr], [TruckCompCity], [TruckCompProv], [TruckCompPostal], [TruckCompPhone]) VALUES (152, N'11A&C Stinnissen Ent', 'Addr 1', N'', N'', N'', N'')");
            Sql("INSERT [dbo].[tblTruckCompanies] ([TruckCompId], [TruckCompName], [TruckCompAddr], [TruckCompCity], [TruckCompProv], [TruckCompPostal], [TruckCompPhone]) VALUES (153, N'112ADM Construction', 'Addr 2', N'', N'', N'', N'')");
             
        }
        
        public override void Down()
        {
        }
    }
}
