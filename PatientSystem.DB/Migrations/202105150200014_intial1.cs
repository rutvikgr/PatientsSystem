namespace PatientSystem.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NOKDetails",
                c => new
                    {
                        NOKId = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        NOKName = c.String(nullable: false, maxLength: 30),
                        RelationshipId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 13),
                        MobileNumber = c.String(nullable: false, maxLength: 13),
                        EmailAddress = c.String(nullable: false, maxLength: 30),
                        PrimaryContact = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.NOKId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.RelationShips", t => t.RelationshipId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.RelationshipId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        SurName = c.String(nullable: false, maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Postal = c.String(nullable: false, maxLength: 10),
                        County = c.String(maxLength: 50),
                        Referred = c.Boolean(nullable: false),
                        ConsentGiven = c.Boolean(nullable: false),
                        ReleaseDate = c.DateTime(storeType: "date"),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.PropertyItems",
                c => new
                    {
                        PropertyId = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        ItemName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Qty = c.Int(nullable: false),
                        CollectedBy = c.String(maxLength: 100),
                        CollectedOn = c.DateTime(storeType: "date"),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.RelationShips",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30),
                        InActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RelationshipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NOKDetails", "RelationshipId", "dbo.RelationShips");
            DropForeignKey("dbo.PropertyItems", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.NOKDetails", "PatientId", "dbo.Patients");
            DropIndex("dbo.PropertyItems", new[] { "PatientId" });
            DropIndex("dbo.NOKDetails", new[] { "RelationshipId" });
            DropIndex("dbo.NOKDetails", new[] { "PatientId" });
            DropTable("dbo.RelationShips");
            DropTable("dbo.PropertyItems");
            DropTable("dbo.Patients");
            DropTable("dbo.NOKDetails");
        }
    }
}
