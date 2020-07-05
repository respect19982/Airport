namespace Airport_IS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class air : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirCraftBrend = c.String(nullable: false),
                        Speed = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        Fuel = c.String(),
                        TailNum = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Departures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrewId = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        AircraftId = c.Int(nullable: false),
                        RateId = c.Int(nullable: false),
                        AirportTaxId = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false, storeType: "date"),
                        NumOfPurchasedTickets = c.Int(nullable: false),
                        NumOfRegisteredPass = c.Int(nullable: false),
                        NumOfCheckedBaggage = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aircraft", t => t.AircraftId, cascadeDelete: true)
                .ForeignKey("dbo.AirportTaxes", t => t.AirportTaxId, cascadeDelete: true)
                .ForeignKey("dbo.Crews", t => t.CrewId, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Rates", t => t.RateId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CrewId)
                .Index(t => t.FlightId)
                .Index(t => t.AircraftId)
                .Index(t => t.RateId)
                .Index(t => t.AirportTaxId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AirportTaxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirportTaxName = c.String(nullable: false),
                        amountOfMoney = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrewName = c.String(nullable: false),
                        NumberPilotsInCrew = c.Int(nullable: false),
                        CrewExperience = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Pilots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(),
                        CrewId = c.Int(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateofBirth = c.DateTime(nullable: false, storeType: "date"),
                        Address = c.String(),
                        PhoneNum = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crews", t => t.CrewId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.PositionId)
                .Index(t => t.CrewId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionName = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        Prize = c.Double(nullable: false),
                        Property = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirlineId = c.Int(nullable: false),
                        SourceAirportId = c.Int(nullable: false),
                        DestinationAirportId = c.Int(nullable: false),
                        FlightName = c.String(nullable: false),
                        DepartureTime = c.Time(nullable: false, precision: 7),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        FlightTime = c.Time(nullable: false, precision: 7),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.DestinationAirportId, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.SourceAirportId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.AirlineId)
                .Index(t => t.SourceAirportId)
                .Index(t => t.DestinationAirportId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirlineName = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirportName = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CityId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCity = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CountryId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateName = c.String(nullable: false),
                        amountOfMoney = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TicketSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PassportSeries = c.String(nullable: false),
                        PassportNum = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        PhoneNum = c.String(),
                        Email = c.String(),
                        PlaceNumber = c.Int(),
                        TicketPrice = c.Double(nullable: false),
                        Class = c.String(nullable: false),
                        Registered = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departures", t => t.DepartureId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.DepartureId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Baggages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketSaleId = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketSales", t => t.TicketSaleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.TicketSaleId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketSales", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rates", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Positions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pilots", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Flights", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departures", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Crews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Baggages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AirportTaxes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Airports", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Airlines", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Aircraft", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TicketSales", "DepartureId", "dbo.Departures");
            DropForeignKey("dbo.Baggages", "TicketSaleId", "dbo.TicketSales");
            DropForeignKey("dbo.Departures", "RateId", "dbo.Rates");
            DropForeignKey("dbo.Flights", "SourceAirportId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "DestinationAirportId", "dbo.Airports");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Airports", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Departures", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "AirlineId", "dbo.Airlines");
            DropForeignKey("dbo.Pilots", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Pilots", "CrewId", "dbo.Crews");
            DropForeignKey("dbo.Departures", "CrewId", "dbo.Crews");
            DropForeignKey("dbo.Departures", "AirportTaxId", "dbo.AirportTaxes");
            DropForeignKey("dbo.Departures", "AircraftId", "dbo.Aircraft");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Baggages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Baggages", new[] { "TicketSaleId" });
            DropIndex("dbo.TicketSales", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TicketSales", new[] { "DepartureId" });
            DropIndex("dbo.Rates", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Countries", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Cities", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Airports", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Airports", new[] { "CityId" });
            DropIndex("dbo.Airlines", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Flights", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Flights", new[] { "DestinationAirportId" });
            DropIndex("dbo.Flights", new[] { "SourceAirportId" });
            DropIndex("dbo.Flights", new[] { "AirlineId" });
            DropIndex("dbo.Positions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pilots", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pilots", new[] { "CrewId" });
            DropIndex("dbo.Pilots", new[] { "PositionId" });
            DropIndex("dbo.Crews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AirportTaxes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Departures", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Departures", new[] { "AirportTaxId" });
            DropIndex("dbo.Departures", new[] { "RateId" });
            DropIndex("dbo.Departures", new[] { "AircraftId" });
            DropIndex("dbo.Departures", new[] { "FlightId" });
            DropIndex("dbo.Departures", new[] { "CrewId" });
            DropIndex("dbo.Aircraft", new[] { "ApplicationUser_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Baggages");
            DropTable("dbo.TicketSales");
            DropTable("dbo.Rates");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Airports");
            DropTable("dbo.Airlines");
            DropTable("dbo.Flights");
            DropTable("dbo.Positions");
            DropTable("dbo.Pilots");
            DropTable("dbo.Crews");
            DropTable("dbo.AirportTaxes");
            DropTable("dbo.Departures");
            DropTable("dbo.Aircraft");
        }
    }
}
