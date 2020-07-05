namespace Airport_IS.Migrations
{
    using Airport_IS.Models;
    using Airport_IS.Models.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var countries = new List<Country>
            {
                new Country{Name = "Ukraine"},
                new Country{Name = "Russia"},
                new Country{Name = "Greece"},
                new Country{Name = "France"},
                new Country{Name = "Spain"},
                new Country{Name = "Norway"},
                new Country{Name = "Turkey"},
                new Country{Name = "Denmark"},
                new Country{Name = "Austria"},
                new Country{Name = "Germany"},
                new Country{Name = "Switzerland"},
            };
            countries.ForEach(s => context.Countries.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var cities = new List<City> {
                new City{NameCity = "Kiev",CountryId = countries.Single(i=> i.Name == "Ukraine").Id},
                new City{NameCity = "Charkow",CountryId = countries.Single(i=> i.Name == "Ukraine").Id},
                new City{NameCity = "Moscow",CountryId = countries.Single(i=> i.Name == "Russia").Id},
                new City{NameCity = "Saint petersburg",CountryId = countries.Single(i=> i.Name == "Russia").Id},
                new City{NameCity = "Athens",CountryId = countries.Single(i=> i.Name == "Greece").Id},
                new City{NameCity = "Thessaloniki",CountryId = countries.Single(i=> i.Name == "Greece").Id},
                new City{NameCity = "Paris",CountryId = countries.Single(i=> i.Name == "France").Id},
                new City{NameCity = "Marseilles",CountryId = countries.Single(i=> i.Name == "France").Id},
                new City{NameCity = "Madrid",CountryId = countries.Single(i=> i.Name == "Spain").Id},
                new City{NameCity = "Barcelona",CountryId = countries.Single(i=> i.Name == "Spain").Id},
                new City{NameCity = "Oslo",CountryId = countries.Single(i=> i.Name == "Norway").Id},
                new City{NameCity = "Bergen",CountryId = countries.Single(i=> i.Name == "Norway").Id},
                new City{NameCity = "Istanbul",CountryId = countries.Single(i=> i.Name == "Turkey").Id},
                new City{NameCity = "Ankara",CountryId = countries.Single(i=> i.Name == "Turkey").Id},
                new City{NameCity = "Copenhagen",CountryId = countries.Single(i=> i.Name == "Denmark").Id},
                new City{NameCity = "Aarhus",CountryId = countries.Single(i=> i.Name == "Denmark").Id},
                new City{NameCity = "Vein",CountryId = countries.Single(i=> i.Name == "Austria").Id},
                new City{NameCity = "Graz",CountryId = countries.Single(i=> i.Name == "Austria").Id},
                new City{NameCity = "Berlin",CountryId = countries.Single(i=> i.Name == "Germany").Id},
                new City{NameCity = "Cologne",CountryId = countries.Single(i=> i.Name == "Germany").Id},
                new City{NameCity = "Zurich",CountryId = countries.Single(i=> i.Name == "Switzerland").Id},
                new City{NameCity = "Geneva",CountryId = countries.Single(i=> i.Name == "Switzerland").Id},
            };

            cities.ForEach(s => context.Cities.AddOrUpdate(p => p.NameCity, s));
            context.SaveChanges();

            var aiports = new List<Airport>
            {
                new Airport{AirportName = "Kiev airport", CityId = cities.Single(i=>i.NameCity=="Kiev").Id},
                new Airport{AirportName = "Charkow airport", CityId = cities.Single(i=>i.NameCity=="Charkow").Id},
                new Airport{AirportName = "Moscow airport", CityId = cities.Single(i=>i.NameCity=="Moscow").Id},
                new Airport{AirportName = "Saint petersburg airport", CityId = cities.Single(i=>i.NameCity=="Saint petersburg").Id},
                new Airport{AirportName = "Athens airport", CityId = cities.Single(i=>i.NameCity=="Athens").Id},
                new Airport{AirportName = "Thessaloniki airport", CityId = cities.Single(i=>i.NameCity=="Thessaloniki").Id},
                new Airport{AirportName = "Paris airport", CityId = cities.Single(i=>i.NameCity=="Paris").Id},
                new Airport{AirportName = "Marseilles airport", CityId = cities.Single(i=>i.NameCity=="Marseilles").Id},
                new Airport{AirportName = "Madrid airport", CityId = cities.Single(i=>i.NameCity=="Madrid").Id},
                new Airport{AirportName = "Barcelona airport", CityId = cities.Single(i=>i.NameCity=="Barcelona").Id},
                new Airport{AirportName = "Oslo airport", CityId = cities.Single(i=>i.NameCity=="Oslo").Id},
                new Airport{AirportName = "Bergen airport", CityId = cities.Single(i=>i.NameCity=="Bergen").Id},
                new Airport{AirportName = "Istanbul airport", CityId = cities.Single(i=>i.NameCity=="Istanbul").Id},
                new Airport{AirportName = "Ankara airport", CityId = cities.Single(i=>i.NameCity=="Ankara").Id},
                new Airport{AirportName = "Copenhagen airport", CityId = cities.Single(i=>i.NameCity=="Copenhagen").Id},
                new Airport{AirportName = "Aarhus airport", CityId = cities.Single(i=>i.NameCity=="Aarhus").Id},
                new Airport{AirportName = "Vein airport", CityId = cities.Single(i=>i.NameCity=="Vein").Id},
                new Airport{AirportName = "Graz airport", CityId = cities.Single(i=>i.NameCity=="Graz").Id},
                new Airport{AirportName = "Berlin airport", CityId = cities.Single(i=>i.NameCity=="Berlin").Id},
                new Airport{AirportName = "Cologne airport", CityId = cities.Single(i=>i.NameCity=="Cologne").Id},
                new Airport{AirportName = "Zurich airport", CityId = cities.Single(i=>i.NameCity=="Zurich").Id},
                new Airport{AirportName = "Geneva airport", CityId = cities.Single(i=>i.NameCity=="Geneva").Id},

            };

            aiports.ForEach(s => context.Airports.AddOrUpdate(p => p.AirportName, s));
            context.SaveChanges();

            var airlines = new List<Airline>
            {
                new Airline{AirlineName = "Atlantic Airlines"},
                new Airline{AirlineName = "Air Europa"},
                new Airline{AirlineName = "Nordwind Airlines"},
                new Airline{AirlineName = "Air France"},
                new Airline{AirlineName = "Air Berlin"},
                new Airline{AirlineName = "Delta Air Lines"},
                new Airline{AirlineName = "Reat Lakes Airlines"},
                new Airline{AirlineName = "Air Canada"},
                new Airline{AirlineName = "Paradise Air"},

            };
            airlines.ForEach(s => context.Airlines.AddOrUpdate(p => p.AirlineName, s));
            context.SaveChanges();


            var aircrafts = new List<Aircraft>
            {
                new Aircraft{AirCraftBrend="Boeing", Fuel = "PT",NumberOfSeats=200,Speed=700,TailNum=707},
                new Aircraft{AirCraftBrend="Boeing", Fuel = "PT",NumberOfSeats=150,Speed=800,TailNum=123},
                new Aircraft{AirCraftBrend="Boeing", Fuel = "PT",NumberOfSeats=300,Speed=600,TailNum=703},
                new Aircraft{AirCraftBrend="Boeing", Fuel = "PT",NumberOfSeats=100,Speed=900,TailNum=322},
                new Aircraft{AirCraftBrend="Airbus S.A.S", Fuel = "TC-1",NumberOfSeats=200,Speed=800,TailNum=231},
                new Aircraft{AirCraftBrend="Airbus S.A.S", Fuel = "TC-1",NumberOfSeats=155,Speed=860,TailNum=312},
                new Aircraft{AirCraftBrend="Airbus S.A.S", Fuel = "TC-1",NumberOfSeats=324,Speed=650,TailNum=111},
                new Aircraft{AirCraftBrend="Airbus S.A.S", Fuel = "TC-1",NumberOfSeats=252,Speed=700,TailNum=125},
                new Aircraft{AirCraftBrend="Beechcraft", Fuel = "T6",NumberOfSeats=50,Speed=1000,TailNum=13},
                new Aircraft{AirCraftBrend="Beechcraft", Fuel = "T6",NumberOfSeats=125,Speed=800,TailNum=25},
                new Aircraft{AirCraftBrend="Beechcraft", Fuel = "T6",NumberOfSeats=20,Speed=1000,TailNum=31},
                new Aircraft{AirCraftBrend="Beechcraft", Fuel = "T6",NumberOfSeats=75,Speed=900,TailNum=52},
                new Aircraft{AirCraftBrend="Bombardier Aerospace", Fuel = "PT",NumberOfSeats=102,Speed=700,TailNum=421},
                new Aircraft{AirCraftBrend="Bombardier Aerospace", Fuel = "PT",NumberOfSeats=80,Speed=800,TailNum=41},
                new Aircraft{AirCraftBrend="Bombardier Aerospace", Fuel = "PT",NumberOfSeats=90,Speed=800,TailNum=61},
                new Aircraft{AirCraftBrend="Bombardier Aerospace", Fuel = "PT",NumberOfSeats=200,Speed=650,TailNum=33},
                new Aircraft{AirCraftBrend="Cessna Aircraft", Fuel = "TC-2",NumberOfSeats=155,Speed=700,TailNum=9},
                new Aircraft{AirCraftBrend="Cessna Aircraft", Fuel = "TC-2",NumberOfSeats=88,Speed=900,TailNum=23},
                new Aircraft{AirCraftBrend="Cessna Aircraft", Fuel = "TC-2",NumberOfSeats=108,Speed=700,TailNum=44},
                new Aircraft{AirCraftBrend="Cessna Aircraft", Fuel = "TC-2",NumberOfSeats=52,Speed=900,TailNum=88},


            };


            var positions = new List<Position>
            {
                new Position{PositionName = "First pilot", Prize = 3000, Salary = 20000 },
                new Position{PositionName = "Second pilot", Prize = 2500, Salary = 15000 },
                new Position{PositionName = "Third pilot", Prize = 2000, Salary = 10000 },
                new Position{PositionName = "Fourth pilot", Prize = 1500, Salary = 7500 },
                new Position{PositionName = "Fifth pilot", Prize = 1000, Salary = 5000 },
            };
            positions.ForEach(s => context.Positions.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            aircrafts.ForEach(s => context.Aircrafts.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var crews = new List<Crew>
            {
                new Crew{CrewName = "First crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Second crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Third crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Fourth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Fifth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Sixth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Seventh crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Eighth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Ninth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Tenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Eleventh crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Twelfth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Thirteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Fourteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Fifteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Sixteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Seventeenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Eighteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Nineteenth crew",NumberPilotsInCrew=1},
                new Crew{CrewName = "Twentieth crew",NumberPilotsInCrew=1},
            };

            crews.ForEach(s => context.Crews.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            var pilots = new List<Pilot>
            {
                new Pilot{FirstName = "Artur",LastName = "Boris" ,CrewId = 1, PositionId = 1, Address = "Nikolaev, central street", DateofBirth = new DateTime(1998,11,14), PhoneNum = "0631500843" },
                new Pilot{FirstName = "Norman",LastName = "Gibbs" ,CrewId = 2, PositionId = 2, Address = "Los Angeles, street 123", DateofBirth = new DateTime(1982,2,22), PhoneNum = "683056288" },
                new Pilot{FirstName = "Mark",LastName = "Richards" ,CrewId = 3, PositionId = 3, Address = "San Francisco, street 41", DateofBirth = new DateTime(1983,3,11), PhoneNum = "376933313" },
                new Pilot{FirstName = "Juniper",LastName = "Higgins",CrewId = 4, PositionId = 4, Address = "Moscow, street 51", DateofBirth = new DateTime(1965,6,26), PhoneNum = "129898676" },
                new Pilot{FirstName = "Joseph",LastName = "Miles",CrewId = 5, PositionId = 5, Address = "Los Angeles, street 55", DateofBirth = new DateTime(1958,4,30), PhoneNum = "833160749" },
                new Pilot{FirstName = "Cuthbert",LastName = "Taylor",CrewId = 6, PositionId = 1, Address = "San Francisco, street 124", DateofBirth = new DateTime(1969,7,23), PhoneNum = "740337845" },
                new Pilot{FirstName = "Frank",LastName = "Ocean",CrewId =7, PositionId = 2, Address = "Moscow, street 66", DateofBirth = new DateTime(1972,11,5), PhoneNum = "481603496" },
                new Pilot{FirstName = "Frank",LastName = "Rich",CrewId = 8, PositionId = 3, Address = "London, street 21", DateofBirth = new DateTime(1978,12,7), PhoneNum = "276818154" },
                new Pilot{FirstName = "Roger",LastName = "Roger",CrewId = 9, PositionId = 4, Address = "Los Angeles, street 2", DateofBirth = new DateTime(1991,10,1), PhoneNum = "842804834" },
                new Pilot{FirstName = "Charles",LastName = "O’Neal",CrewId = 10, PositionId = 5, Address = "San Francisco street 6", DateofBirth = new DateTime(1990,5,24), PhoneNum = "331916651" },
                new Pilot{FirstName = "Chester",LastName = "Cameron",CrewId = 11, PositionId = 1, Address = "Moscow, street 7", DateofBirth = new DateTime(1980,1,18), PhoneNum = "497863859" },
                new Pilot{FirstName = "Walter",LastName = "Davis",CrewId = 12, PositionId = 2, Address = "London, street 61", DateofBirth = new DateTime(1966,12,11), PhoneNum = "199613418" },
                new Pilot{FirstName = "Joshua",LastName = "Cain",CrewId = 13, PositionId = 3, Address = "Los Angeles, street 87", DateofBirth = new DateTime(1994,9,21), PhoneNum = "689920065" },
                new Pilot{FirstName = "Buddy",LastName = "Harrington",CrewId = 14, PositionId = 4, Address = "San Francisco, street 34", DateofBirth = new DateTime(1984,5,26), PhoneNum = "160970809" },
                new Pilot{FirstName = "Mark",LastName = "Bradford",CrewId = 15, PositionId = 5, Address = "Moscow, street 23", DateofBirth = new DateTime(1990,2,15), PhoneNum = "698938517" },
                new Pilot{FirstName = "Hugo",LastName = "Hines",CrewId = 16, PositionId = 1, Address = "Los Angeles, street 93", DateofBirth = new DateTime(1956,2,11), PhoneNum = "816026710" },
                new Pilot{FirstName = "Ralf",LastName = "Alexander",CrewId = 17, PositionId = 2, Address = "San Francisco, street 59", DateofBirth = new DateTime(1961,8,18), PhoneNum = "507882386" },
                new Pilot{FirstName = "Steven",LastName = "McKinney",CrewId = 18, PositionId = 3, Address = "Moscow, street 27", DateofBirth = new DateTime(1973,6,16), PhoneNum = "173193065" },
                new Pilot{FirstName = "Robert",LastName = "Hicks",CrewId = 19, PositionId = 4, Address = "London, street 74", DateofBirth = new DateTime(1970,7,7), PhoneNum = "841475467" },
                new Pilot{FirstName = "Mervyn",LastName = "Hunter",CrewId = 20, PositionId = 5, Address = "San Francisco, street 94", DateofBirth = new DateTime(1980,10,8), PhoneNum = "457455235" },
                new Pilot{FirstName = "Steven",LastName = "Hunt",PositionId = 1, Address = "London, street 69", DateofBirth = new DateTime(1978,1,20), PhoneNum = "830368023" },
                new Pilot{FirstName = "Robert",LastName = "Alexander",CrewId = 1, PositionId = 5, Address = "Barcelona, street 95", DateofBirth = new DateTime(1981,10,8), PhoneNum = "346346346" },
                new Pilot{FirstName = "Mervyn",LastName = "Hunter",CrewId = 2, PositionId = 4, Address = "Madrid, street 32", DateofBirth = new DateTime(1967,2,3), PhoneNum = "346345123" },
                new Pilot{FirstName = "Ronald",LastName = "Stafford",CrewId = 3, PositionId = 3, Address = "Barcelona, street 22", DateofBirth = new DateTime(1976,5,23), PhoneNum = "235233413" },
                new Pilot{FirstName = "Christopher",LastName = "Thompson",CrewId = 4, PositionId = 2, Address = "San Francisco, street 3", DateofBirth = new DateTime(1985,11,29), PhoneNum = "235347523" },
                new Pilot{FirstName = "Magnus",LastName = "Dalton",CrewId = 5, PositionId = 1, Address = "Moscow, street 22", DateofBirth = new DateTime(1968,12,1), PhoneNum = "876456735" },
                new Pilot{FirstName = "Leslie",LastName = "Small",CrewId = 6, PositionId = 5, Address = "Kiev, street 2", DateofBirth = new DateTime(1987,11,8), PhoneNum = "9778045522" },
                new Pilot{FirstName = "Thomas",LastName = "Curtis",CrewId = 7, PositionId = 4, Address = "Los Angeles, street 31", DateofBirth = new DateTime(1978,11,22), PhoneNum = "458789456" },
                new Pilot{FirstName = "Henry",LastName = "King",CrewId = 8, PositionId = 3, Address = "Paris, street 23", DateofBirth = new DateTime(1980,4,5), PhoneNum = "74563412" },
                new Pilot{FirstName = "Cuthbert",LastName = "Cannon",CrewId = 9, PositionId = 2, Address = "Cologne, street 24", DateofBirth = new DateTime(1990,7,21), PhoneNum = "745845561" },
                new Pilot{FirstName = "Walter",LastName = "Ramsey",CrewId = 10, PositionId = 1, Address = "Berlin, street 11", DateofBirth = new DateTime(1991,3,7), PhoneNum = "21334745" },
                new Pilot{FirstName = "William",LastName = "Atkinson",CrewId = 11, PositionId = 5, Address = "San Francisco, street 94", DateofBirth = new DateTime(1986,8,26), PhoneNum = "1234577078" },
                new Pilot{FirstName = "Peter",LastName = "Morton",CrewId = 12, PositionId = 4, Address = "New York, street 21", DateofBirth = new DateTime(1989,6,15), PhoneNum = "43531231" },
                new Pilot{FirstName = "Alban",LastName = "Reynolds",CrewId = 13, PositionId = 3, Address = "Tokyo, street 2", DateofBirth = new DateTime(1979,9,13), PhoneNum = "123465890" },
                new Pilot{FirstName = "Daniel",LastName = "Cobb",CrewId = 14, PositionId = 2, Address = "Sydney, street 22", DateofBirth = new DateTime(1976,10,3), PhoneNum = "324123125" },
                new Pilot{FirstName = "Thomas",LastName = "Bryant",CrewId = 15, PositionId = 1, Address = "Chicago, street 51", DateofBirth = new DateTime(1960,3,25), PhoneNum = "345344785" },
                new Pilot{FirstName = "Tyrone",LastName = "Webster",CrewId = 16, PositionId = 5, Address = "Atlanta, street 37", DateofBirth = new DateTime(1973,10,18), PhoneNum = "111111111" },
                new Pilot{FirstName = "Donald",LastName = "Thornton",CrewId = 17, PositionId = 4, Address = "Pekin, street 23", DateofBirth = new DateTime(1985,9,12), PhoneNum = "23534683" },
                new Pilot{FirstName = "David",LastName = "Baker",CrewId = 18, PositionId = 3, Address = "Oslo, street 56", DateofBirth = new DateTime(1979,1,1), PhoneNum = "458353479" },
                new Pilot{FirstName = "Alan",LastName = "Merritt",CrewId = 19, PositionId = 2, Address = "Charkow, street 30", DateofBirth = new DateTime(1970,5,10), PhoneNum = "397864734" },
                new Pilot{FirstName = "Claude",LastName = "Hancock",CrewId = 20, PositionId = 1, Address = "London, street 19", DateofBirth = new DateTime(1961,2,2), PhoneNum = "862356764" },

            };

            foreach (Crew cr in crews)
            {
                int k = pilots.Count(p => p.CrewId == cr.Id);
                cr.NumberPilotsInCrew = k;
                context.Crews.AddOrUpdate(p => p.Id, cr);
            }

            pilots.ForEach(s => context.Pilots.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();




            var rates = new List<Rate>
            {
                new Rate{RateName = "First daily rate", amountOfMoney = 50},
                new Rate{RateName = "Second daily rate", amountOfMoney = 100},
                new Rate{RateName = "Third daily rate", amountOfMoney = 150},
                new Rate{RateName = "Fourth daily rate", amountOfMoney = 200 },
                new Rate{RateName = "Fifth daily rate", amountOfMoney = 250 },
                new Rate{RateName = "First night rate", amountOfMoney = 100 },
                new Rate{RateName = "Second night rate", amountOfMoney = 150 },
                new Rate{RateName = "Third night rate", amountOfMoney = 200 },
                new Rate{RateName = "Fourth night rate", amountOfMoney = 250 },
                new Rate{RateName = "Fifth night rate", amountOfMoney = 300 }
            };

            rates.ForEach(s => context.Rates.AddOrUpdate(p => p.RateName, s));
            context.SaveChanges();

            var airportTaxes = new List<AirportTax>
            {
                new AirportTax{AirportTaxName = "Daily summer", amountOfMoney = 250},
                new AirportTax{AirportTaxName = "Night summer", amountOfMoney = 300},
                new AirportTax{AirportTaxName = "Daily autumn", amountOfMoney = 180},
                new AirportTax{AirportTaxName = "Night autumn", amountOfMoney = 200},
                new AirportTax{AirportTaxName = "Daily winter", amountOfMoney = 150},
                new AirportTax{AirportTaxName = "Night winter", amountOfMoney = 170},
                new AirportTax{AirportTaxName = "Daily spring", amountOfMoney = 225},
                new AirportTax{AirportTaxName = "Night spring", amountOfMoney = 275},
                new AirportTax{AirportTaxName = "Daily standard", amountOfMoney = 190},
                new AirportTax{AirportTaxName = "Night standard", amountOfMoney = 220},
            };

            airportTaxes.ForEach(s => context.AirportTaxes.AddOrUpdate(p => p.AirportTaxName, s));
            context.SaveChanges();

            var flights = new List<Flight>
            {
                 new Flight{FlightName = "Kiev - Moscow",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Moscow airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Delta Air Lines").Id, DepartureTime = new DateTime(1978,1,20,8,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,11,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},
                 new Flight{FlightName = "Moscow - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Moscow airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Delta Air Lines").Id, DepartureTime = new DateTime(1978,1,20,12,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Charkow",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Charkow airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Europa").Id, DepartureTime = new DateTime(1978,1,20,7,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,9,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},
                 new Flight{FlightName = "Charkow - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Charkow airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Europa").Id, DepartureTime = new DateTime(1978,1,20,10,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,12,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Saint petersburg",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Saint petersburg airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Atlantic Airlines").Id, DepartureTime = new DateTime(1978,1,20,11,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},
                 new Flight{FlightName = "Saint petersburg - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Saint petersburg airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Atlantic Airlines").Id, DepartureTime = new DateTime(1978,1,20,16,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,20,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Cologne",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Cologne airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Europa").Id, DepartureTime = new DateTime(1978,1,20,14,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,17,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},
                 new Flight{FlightName = "Cologne - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Cologne airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Europa").Id, DepartureTime = new DateTime(1978,1,20,18,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,21,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Berlin",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Berlin airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,12,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,30,0).TimeOfDay},
                 new Flight{FlightName = "Berlin - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Berlin airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,16,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,18,30,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,30,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Athens",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Athens airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,12,20,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,40,0).TimeOfDay},
                 new Flight{FlightName = "Athens - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Athens airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,16,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,18,40,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,40,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Thessaloniki",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Thessaloniki airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,20,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,23,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},
                 new Flight{FlightName = "Thessaloniki - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Thessaloniki airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,7,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,10,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Paris",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Paris airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,10,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,14,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},
                 new Flight{FlightName = "Paris - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Paris airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,17,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,21,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Marseilles",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Marseilles airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,16,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,21,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,30,0).TimeOfDay},
                 new Flight{FlightName = "Marseilles - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Marseilles airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,11,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,16,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,30,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Madrid",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Madrid airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,8,20,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,13,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,40,0).TimeOfDay},
                 new Flight{FlightName = "Madrid - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Madrid airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,14,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,18,40,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,40,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Barcelona",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Barcelona airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,7,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,11,30,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},
                 new Flight{FlightName = "Barcelona - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Barcelona airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,14,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,18,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,4,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Oslo",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Oslo airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,15,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,20,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,5,0,0).TimeOfDay},
                 new Flight{FlightName = "Oslo - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Oslo airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,7,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,12,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,5,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Bergen",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Bergen airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,8,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,14,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,6,0,0).TimeOfDay},
                 new Flight{FlightName = "Bergen - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Bergen airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,16,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,22,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,6,9,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Istanbul",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Istanbul airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,10,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,12,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},
                 new Flight{FlightName = "Istanbul - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Istanbul airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,21,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,23,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Ankara",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Ankara airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,11,40,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,14,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,20,0).TimeOfDay},
                 new Flight{FlightName = "Ankara - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Ankara airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,21,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,23,20,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,20,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Copenhagen",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Copenhagen airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,18,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,21,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,30,0).TimeOfDay},
                 new Flight{FlightName = "Copenhagen - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Copenhagen airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,9,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,11,30,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,30,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Aarhus",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Aarhus airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,19,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,22,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},
                 new Flight{FlightName = "Aarhus - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Aarhus airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,12,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Vein",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Vein airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,7,10,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,9,10,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},
                 new Flight{FlightName = "Vein - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Vein airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,20,20,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,22,20,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Graz",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Graz airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,8,20,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,10,40,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,20,0).TimeOfDay},
                 new Flight{FlightName = "Graz - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Graz airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,14,40,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,17,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,20,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Geneva",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Geneva airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,7,30,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,10,30,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},
                 new Flight{FlightName = "Geneva - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Geneva airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Kiev airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,12,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,3,0,0).TimeOfDay},

                 new Flight{FlightName = "Kiev - Zurich",SourceAirportId = aiports.Single(i=>i.AirportName=="Kiev airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Zurich airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,18,0,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,20,45,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,45,0).TimeOfDay},
                 new Flight{FlightName = "Zurich - Kiev",SourceAirportId = aiports.Single(i=>i.AirportName=="Zurich airport").Id,DestinationAirportId= aiports.Single(i=>i.AirportName=="Zurich airport").Id,
                 AirlineId = airlines.Single(i=>i.AirlineName=="Air Berlin").Id, DepartureTime = new DateTime(1978,1,11,12,15,0).TimeOfDay, ArrivalTime = new DateTime(1978,1,20,15,0,0).TimeOfDay,
                     FlightTime = new DateTime(1978,1,20,2,45,0).TimeOfDay},

            };


            flights.ForEach(s => context.Flights.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var departures = new List<Departure>
            {
                new Departure{CrewId = 5, FlightId = flights.Single(i=>i.FlightName=="Kiev - Moscow").Id, AircraftId = aircrafts.Single(i=>i.Id == 5).Id, DepartureDate = new DateTime(2020,07,01), 
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 13, FlightId = flights.Single(i=>i.FlightName=="Kiev - Berlin").Id, AircraftId = aircrafts.Single(i=>i.Id == 13).Id, DepartureDate = new DateTime(2019,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 6, FlightId = flights.Single(i=>i.FlightName=="Kiev - Thessaloniki").Id, AircraftId = aircrafts.Single(i=>i.Id == 6).Id, DepartureDate = new DateTime(2019,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 10, FlightId = flights.Single(i=>i.FlightName=="Kiev - Paris").Id, AircraftId = aircrafts.Single(i=>i.Id == 10).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 3, FlightId = flights.Single(i=>i.FlightName=="Kiev - Barcelona").Id, AircraftId = aircrafts.Single(i=>i.Id == 3).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 11, FlightId = flights.Single(i=>i.FlightName=="Kiev - Bergen").Id, AircraftId = aircrafts.Single(i=>i.Id == 11).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 15, FlightId = flights.Single(i=>i.FlightName=="Kiev - Istanbul").Id, AircraftId = aircrafts.Single(i=>i.Id == 15).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 8, FlightId = flights.Single(i=>i.FlightName=="Kiev - Aarhus").Id, AircraftId = aircrafts.Single(i=>i.Id == 8).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 12, FlightId = flights.Single(i=>i.FlightName=="Kiev - Vein").Id, AircraftId = aircrafts.Single(i=>i.Id == 12).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 20, FlightId = flights.Single(i=>i.FlightName=="Kiev - Geneva").Id, AircraftId = aircrafts.Single(i=>i.Id == 20).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},



                new Departure{CrewId = 9, FlightId = flights.Single(i=>i.FlightName=="Saint petersburg - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 9).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 1, FlightId = flights.Single(i=>i.FlightName=="Charkow - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 1).Id, DepartureDate = new DateTime(2019,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 17, FlightId = flights.Single(i=>i.FlightName=="Athens - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 17).Id, DepartureDate = new DateTime(2019,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 2, FlightId = flights.Single(i=>i.FlightName=="Cologne - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 2).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 14, FlightId = flights.Single(i=>i.FlightName=="Marseilles - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 14).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 18, FlightId = flights.Single(i=>i.FlightName=="Madrid - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 18).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 7, FlightId = flights.Single(i=>i.FlightName=="Oslo - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 7).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 19, FlightId = flights.Single(i=>i.FlightName=="Ankara - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 19).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 4, FlightId = flights.Single(i=>i.FlightName=="Copenhagen - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 4).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 16, FlightId = flights.Single(i=>i.FlightName=="Graz - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 16).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 20, FlightId = flights.Single(i=>i.FlightName=="Zurich - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 20).Id, DepartureDate = new DateTime(2020,07,01),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},




                new Departure{CrewId = 9, FlightId = flights.Single(i=>i.FlightName=="Kiev - Saint petersburg").Id, AircraftId = aircrafts.Single(i=>i.Id == 9).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 1, FlightId = flights.Single(i=>i.FlightName=="Kiev - Charkow").Id, AircraftId = aircrafts.Single(i=>i.Id == 1).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 17, FlightId = flights.Single(i=>i.FlightName=="Kiev - Athens").Id, AircraftId = aircrafts.Single(i=>i.Id == 17).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 2, FlightId = flights.Single(i=>i.FlightName=="Kiev - Cologne").Id, AircraftId = aircrafts.Single(i=>i.Id == 2).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 14, FlightId = flights.Single(i=>i.FlightName=="Kiev - Marseilles").Id, AircraftId = aircrafts.Single(i=>i.Id == 14).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 18, FlightId = flights.Single(i=>i.FlightName=="Kiev - Madrid").Id, AircraftId = aircrafts.Single(i=>i.Id == 18).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 7, FlightId = flights.Single(i=>i.FlightName=="Kiev - Oslo").Id, AircraftId = aircrafts.Single(i=>i.Id == 7).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 19, FlightId = flights.Single(i=>i.FlightName=="Kiev - Ankara").Id, AircraftId = aircrafts.Single(i=>i.Id == 19).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 4, FlightId = flights.Single(i=>i.FlightName=="Kiev - Copenhagen").Id, AircraftId = aircrafts.Single(i=>i.Id == 4).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 16, FlightId = flights.Single(i=>i.FlightName=="Kiev - Graz").Id, AircraftId = aircrafts.Single(i=>i.Id == 16).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 20, FlightId = flights.Single(i=>i.FlightName=="Kiev - Zurich").Id, AircraftId = aircrafts.Single(i=>i.Id == 20).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},

                
                
                new Departure{CrewId = 5, FlightId = flights.Single(i=>i.FlightName=="Moscow - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 5).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 13, FlightId = flights.Single(i=>i.FlightName=="Berlin - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 13).Id, DepartureDate = new DateTime(2019,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 6, FlightId = flights.Single(i=>i.FlightName=="Thessaloniki - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 6).Id, DepartureDate = new DateTime(2019,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 10, FlightId = flights.Single(i=>i.FlightName=="Paris - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 10).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 3, FlightId = flights.Single(i=>i.FlightName=="Barcelona - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 3).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 11, FlightId = flights.Single(i=>i.FlightName=="Bergen - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 11).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 15, FlightId = flights.Single(i=>i.FlightName=="Istanbul - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 15).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 8, FlightId = flights.Single(i=>i.FlightName=="Aarhus - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 8).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 12, FlightId = flights.Single(i=>i.FlightName=="Vein - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 12).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},
                new Departure{CrewId = 20, FlightId = flights.Single(i=>i.FlightName=="Geneva - Kiev").Id, AircraftId = aircrafts.Single(i=>i.Id == 20).Id, DepartureDate = new DateTime(2020,07,02),
                    AirportTaxId = airportTaxes.Single(i=>i.AirportTaxName == "Daily summer").Id, RateId = rates.Single(i=>i.RateName=="First daily rate").Id},

            };

            departures.ForEach(s => context.Departures.AddOrUpdate(p => p.DepartureDate, s));
            context.SaveChanges();

            
        }
    }
}
