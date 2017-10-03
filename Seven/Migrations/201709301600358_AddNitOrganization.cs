namespace Seven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNitOrganization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afps",
                c => new
                    {
                        AfpID = c.Int(nullable: false, identity: true),
                        AfpDescription = c.String(),
                    })
                .PrimaryKey(t => t.AfpID);
            
            CreateTable(
                "dbo.ModelContracts",
                c => new
                    {
                        ModelContractID = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdmision = c.DateTime(nullable: false),
                        Percent = c.Double(nullable: false),
                        OrganitationID = c.Int(nullable: false),
                        SupervisorID = c.Int(nullable: false),
                        ModelTypeID = c.Int(nullable: false),
                        ProfitCenterID = c.Int(nullable: false),
                        EpsID = c.Int(nullable: false),
                        AfpID = c.Int(nullable: false),
                        ArlID = c.Int(nullable: false),
                        CompensationID = c.Int(nullable: false),
                        ModelPerson_ModelID = c.Int(),
                    })
                .PrimaryKey(t => t.ModelContractID)
                .ForeignKey("dbo.Afps", t => t.AfpID)
                .ForeignKey("dbo.Arls", t => t.ArlID)
                .ForeignKey("dbo.Compensations", t => t.CompensationID)
                .ForeignKey("dbo.Eps", t => t.EpsID)
                .ForeignKey("dbo.ModelTypes", t => t.ModelTypeID)
                .ForeignKey("dbo.ModelPersons", t => t.ModelPerson_ModelID)
                .ForeignKey("dbo.Supervisors", t => t.SupervisorID)
                .ForeignKey("dbo.Organitations", t => t.OrganitationID)
                .ForeignKey("dbo.ProfitCenters", t => t.ProfitCenterID);
            
            CreateTable(
                "dbo.Arls",
                c => new
                    {
                        ArlID = c.Int(nullable: false, identity: true),
                        ArlDescription = c.String(),
                    })
                .PrimaryKey(t => t.ArlID);
            
            CreateTable(
                "dbo.Compensations",
                c => new
                    {
                        CompensationID = c.Int(nullable: false, identity: true),
                        CompensationDescription = c.String(),
                    })
                .PrimaryKey(t => t.CompensationID);
            
            CreateTable(
                "dbo.Eps",
                c => new
                    {
                        EpsID = c.Int(nullable: false, identity: true),
                        EpsDescription = c.String(),
                    })
                .PrimaryKey(t => t.EpsID);
            
            CreateTable(
                "dbo.ModelTypes",
                c => new
                    {
                        ModelTypeID = c.Int(nullable: false, identity: true),
                        ModelTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.ModelTypeID);
            
            CreateTable(
                "dbo.Organitations",
                c => new
                    {
                        OrganitationID = c.Int(nullable: false, identity: true),
                        Nit = c.String(),
                        OrganitationName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.OrganitationID);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        BudgetID = c.Int(nullable: false, identity: true),
                        OrganitationID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        BudgetDate = c.DateTime(nullable: false),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BudgetID)
                .ForeignKey("dbo.ModelPersons", t => t.ModelID)
                .ForeignKey("dbo.Organitations", t => t.OrganitationID);
            
            CreateTable(
                "dbo.ModelPersons",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        IdentityCard = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Nick = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        ProfileType = c.String(),
                    })
                .PrimaryKey(t => t.ModelID);
            
            CreateTable(
                "dbo.ModelPages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ModelID = c.Int(nullable: false),
                        PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModelPersons", t => t.ModelID)
                .ForeignKey("dbo.Pages", t => t.PageID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        PageUrl = c.String(),
                        TipValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PageTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageTypes", t => t.PageTypeID);
            
            CreateTable(
                "dbo.PageTypes",
                c => new
                    {
                        PageTypeID = c.Int(nullable: false, identity: true),
                        PageTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PageTypeID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        QtyTokens = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.ModelPersons", t => t.ModelID)
                .ForeignKey("dbo.Orders", t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrganitationID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        SupervisorID = c.Int(nullable: false),
                        PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Organitations", t => t.OrganitationID)
                .ForeignKey("dbo.Supervisors", t => t.SupervisorID);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        SupervisorID = c.Int(nullable: false, identity: true),
                        IdentityCard = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        ProfileType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupervisorID);
            
            CreateTable(
                "dbo.ProfitCenters",
                c => new
                    {
                        ProfitCenterID = c.Int(nullable: false, identity: true),
                        ProfitCenterDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProfitCenterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelContracts", "ProfitCenterID", "dbo.ProfitCenters");
            DropForeignKey("dbo.ModelContracts", "OrganitationID", "dbo.Organitations");
            DropForeignKey("dbo.Budgets", "OrganitationID", "dbo.Organitations");
            DropForeignKey("dbo.Orders", "SupervisorID", "dbo.Supervisors");
            DropForeignKey("dbo.ModelContracts", "SupervisorID", "dbo.Supervisors");
            DropForeignKey("dbo.Orders", "OrganitationID", "dbo.Organitations");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ModelID", "dbo.ModelPersons");
            DropForeignKey("dbo.Pages", "PageTypeID", "dbo.PageTypes");
            DropForeignKey("dbo.ModelPages", "PageID", "dbo.Pages");
            DropForeignKey("dbo.ModelPages", "ModelID", "dbo.ModelPersons");
            DropForeignKey("dbo.ModelContracts", "ModelPerson_ModelID", "dbo.ModelPersons");
            DropForeignKey("dbo.Budgets", "ModelID", "dbo.ModelPersons");
            DropForeignKey("dbo.ModelContracts", "ModelTypeID", "dbo.ModelTypes");
            DropForeignKey("dbo.ModelContracts", "EpsID", "dbo.Eps");
            DropForeignKey("dbo.ModelContracts", "CompensationID", "dbo.Compensations");
            DropForeignKey("dbo.ModelContracts", "ArlID", "dbo.Arls");
            DropForeignKey("dbo.ModelContracts", "AfpID", "dbo.Afps");
            DropTable("dbo.ProfitCenters");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.PageTypes");
            DropTable("dbo.Pages");
            DropTable("dbo.ModelPages");
            DropTable("dbo.ModelPersons");
            DropTable("dbo.Budgets");
            DropTable("dbo.Organitations");
            DropTable("dbo.ModelTypes");
            DropTable("dbo.Eps");
            DropTable("dbo.Compensations");
            DropTable("dbo.Arls");
            DropTable("dbo.ModelContracts");
            DropTable("dbo.Afps");
        }
    }
}
