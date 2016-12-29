using CarMat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class CarMatDataSeeder
    {
        private CMContext _context;
        private UserManager<CMUser> _userManager;

        public CarMatDataSeeder(CMContext context, UserManager<CMUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void SeedData()
        {
            //Create provinces

            if (!_context.Provinces.Any())
            {
                List<Province> polishProvinces = new List<Province>
                {
                    new Province { Name = "dolnośląskie"},
                    new Province { Name = "kujawsko-pomorskie"},
                    new Province { Name = "lubelskie"},
                    new Province { Name = "lubuskie"},
                    new Province { Name = "łódzkie"},
                    new Province { Name = "małopolskie"},
                    new Province { Name = "mazowieckie"},
                    new Province { Name = "opolskie"},
                    new Province { Name = "podkarpackie"},
                    new Province { Name = "podlaskie"},
                    new Province { Name = "pomorskie"},
                    new Province { Name = "śląskie"},
                    new Province { Name = "świętokrzyskie"},
                    new Province { Name = "warmińsko-mazurskie"},
                    new Province { Name = "wielkopolskie"},
                    new Province { Name = "zachodniopomorskie"},
                };

                _context.Provinces.AddRange(polishProvinces);
                await _context.SaveChangesAsync();
            }

            //Create brands

            if (!_context.VehicleBrands.Any())
            {
                List<VehicleBrand> brands = new List<VehicleBrand>
                {
                    new VehicleBrand { Name = "Alfa Romeo" },
                    new VehicleBrand { Name = "Aston Martin" },
                    new VehicleBrand { Name = "Audi" },
                    new VehicleBrand { Name = "BMW" },
                    new VehicleBrand { Name = "Bentley" },
                    new VehicleBrand { Name = "Bugatti" },
                    new VehicleBrand { Name = "Cadillac" },
                    new VehicleBrand { Name = "Chevrolet" },
                    new VehicleBrand { Name = "Chrysler" },
                    new VehicleBrand { Name = "Citroen" },
                    new VehicleBrand { Name = "Dacia" },
                    new VehicleBrand { Name = "Daewoo" },
                    new VehicleBrand { Name = "Daihatsu" },
                    new VehicleBrand { Name = "Dodge" },
                    new VehicleBrand { Name = "Ferrari" },
                    new VehicleBrand { Name = "Fiat" },
                    new VehicleBrand { Name = "Ford" },
                    new VehicleBrand { Name = "Honda" },
                    new VehicleBrand { Name = "Hummer" },
                    new VehicleBrand { Name = "Hyundai" },
                    new VehicleBrand { Name = "Infiniti" },
                    new VehicleBrand { Name = "Isuzu" },
                    new VehicleBrand { Name = "Jaguar" },
                    new VehicleBrand { Name = "Jeep" },
                    new VehicleBrand { Name = "Kia" },
                    new VehicleBrand { Name = "Lamborghini" },
                    new VehicleBrand { Name = "Lancia" },
                    new VehicleBrand { Name = "Land Rover" },
                    new VehicleBrand { Name = "Lexus" },
                    new VehicleBrand { Name = "Maserati" },
                    new VehicleBrand { Name = "Mazda" },
                    new VehicleBrand { Name = "Mercedes-Benz" },
                    new VehicleBrand { Name = "Mini" },
                    new VehicleBrand { Name = "Mitsubishi" },
                    new VehicleBrand { Name = "Nissan" },
                    new VehicleBrand { Name = "Opel" },
                    new VehicleBrand { Name = "Peugeot" },
                    new VehicleBrand { Name = "Polonez" },
                    new VehicleBrand { Name = "Porsche" },
                    new VehicleBrand { Name = "Renault" },
                    new VehicleBrand { Name = "Rolls-Royce" },
                    new VehicleBrand { Name = "Rover" },
                    new VehicleBrand { Name = "Saab" },
                    new VehicleBrand { Name = "Seat" },
                    new VehicleBrand { Name = "Skoda" },
                    new VehicleBrand { Name = "Smart" },
                    new VehicleBrand { Name = "Subaru" },
                    new VehicleBrand { Name = "Suzuki" },
                    new VehicleBrand { Name = "Toyota" },
                    new VehicleBrand { Name = "Volkswagen" },
                    new VehicleBrand { Name = "Volvo" },
                };

                _context.VehicleBrands.AddRange(brands);

                await _context.SaveChangesAsync();
            }

            //Create models for each brand

            if (!_context.VehicleModels.Any())
            {

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Alfa Romeo",
                   new List<string> { "33", "75", "145", "146", "147", "155", "156", "159", "164", "166", "4C",
                                        "Brera", "Crosswagon", "GT", "GTV", "Giulietta", "MiTo", "Spider", "Sportwagon",});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Aston Martin",
                   new List<string> { "DB7", "DB9", "DBS", "Rapide", "V8 Vantage", "V12 Vanquish", "V12 Vantage" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Audi",
                   new List<string> { "80", "90", "RS3", "SQ5", "100", "A1", "A2", "A3", "A4", "A4 Allroad",
                                        "A5", "A6", "A6 Allroad", "A7", "A8", "Q2", "Q3", "Q5", "Q7",
                                        "R8", "RS Q3", "RS4", "RS5", "RS6", "RS7", "S1", "S3", "S4",
                                        "S5", "S6", "S7", "S8", "TT", "TT RS", "TT S", "V8"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "BMW",
                    new List<string> { "Seria 1", "Seria 2", "Seria 3", "Seria 4", "Seria 5", "Seria 6",
                                        "Seria 7", "Seria 8", "M2", "M3", "M4", "M5", "M6", "X1", "X3",
                                        "X4", "X5", "X5 M", "X6", "X6 M", "Z3", "Z4", "i3", "i8"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Bentley",
                    new List<string> { "Continental Flying Spur", "Continental GT", "Mulsanne" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Bugatti",
                    new List<string> { "Veyron" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Cadillac",
                   new List<string> { "BLS", "CTS", "DTS", "DeVille", "Eldorado", "Escalade", "Fleetwood", "SRX", "STS" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Chevrolet",
                    new List<string> { "Aveo", "Camaro", "Captiva", "Corvette", "Cruze", "Epica", "Impala", "Kalos",
                                        "Lacetti", "Lumina", "Malibu", "Matiz", "Nubira", "Orlando", "Rezzo", "Silverado",
                                        "Spark"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Chrysler",
                   new List<string> { "300C", "300M", "Aspen", "Concorde", "Crossfire", "Grand Voyager", "Le Baron",
                                        "Neon", "New Yorker", "PT Cruiser", "Pacifica", "Sebring", "Stratus",
                                        "Town & Country", "Voyager"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Citroen",
                   new List<string> { "2 CV", "AX", "Berlingo", "C-Crosser", "C-Elysee", "C1", "C2", "C3",
                                        "C3 Picasso", "C3 Pluriel", "C4", "C4 Aircross", "C4 Cactus",
                                        "C4 Grand Picasso", "C4 Picasso", "C5", "C6", "C8", "CX", "DS",
                                        "DS3", "DS4", "DS5", "Evasion", "Jumper", "Jumpy Combi", "Nemo",
                                        "Saxo", "XM", "Xantia", "Xsara", "Xsara Picasso", "ZX"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Dacia",
                   new List<string> { "Dokker", "Dokker Van", "Duster", "Lodgy", "Logan", "Logan Van", "Sandero",
                                        "Sandero Stepway"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Daewoo",
                   new List<string> { "Espero", "Kalos", "Korando", "Lacetii", "Lanos", "Leganza", "Matiz", "Nexia", "Nubira",
                                        "Rezzo", "Tacuma", "Tico"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Daihatsu",
                   new List<string> { "Applause", "Charade", "Cuore", "Feroza", "Gran Move", "Materia", "Move", "Rocky", "Sirion",
                                        "Terios", "Trevis", "YRV"});


                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                   "Dodge",
                   new List<string> { "Avenger", "Caliber", "Caravan", "Challenger", "Charger", "Dakota", "Durango", "Grand Caravan",
                                        "Intrepid", "Journey", "Magnum", "Neon", "Nitro", "RAM", "Stealth", "Stratus", "Viper"});

                 await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Ferrari",
                    new List<string> { "360", "458 Italia", "488", "599 GTB", "California", "F12 Berlinetta", "F430", "FF"});

                 await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Fiat",
                    new List<string> { "125p", "126", "500", "500L", "500X", "Albea", "Brava", "Bravo", "Cinquecento", "Coupe",
                                        "Croma", "Doblo", "Ducato", "Fiorino", "Freemont", "Grande Punto", "Idea", "Linea",
                                        "Marea", "Multipla", "Palio", "Panda", "Punto", "Qubo", "Scudo", "Sedici", "Seicento",
                                        "Siena", "Stilo", "Strada", "Tipo", "Uno"});

                 await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Ford",
                    new List<string> { "B-MAX", "C-MAX", "Cougar", "Courier", "Edge", "Escape", "Escort", "Fiesta", "Focus",
                                        "Focux C-Max", "Fusion", "Galaxy", "Grand C-Max", "KA", "Kuga", "Mondeo", "Mustang",
                                        "Orion", "Probe", "Puma", "Ranger", "S-MAX", "Scorpio", "Sierra", "Streetka", "Tourneo Connect",
                                        "Tourneo Currier", "Tourneo Custom", "Transit", "Windstar"});

                 await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Honda",
                    new List<string> { "Accord", "CR-V", "CR-Z", "CRX", "City", "Civic", "FR-V", "HR-V", "Jazz", "Legend",
                                        "Prelude", "S2000", "Stream"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Hummer",
                    new List<string> { "H1", "H2", "H3"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Hyundai",
                    new List<string> { "Accent", "Atos", "Coupe", "Elantra", "Galloper", "Genesis", "Getz", "Santa Fe", "Tucson",
                                        "i10", "i20", "i30", "i40", "ix20", "ix35", "ix55"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Infiniti",
                    new List<string> { "EX", "FX", "G", "M", "Q30", "Q45", "Q50", "Q70", "QX", "QX30", "QX70"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Isuzu",
                    new List<string> { "D-Max", "Trooper"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Jaguar",
                    new List<string> { "F-Pace", "F-Type", "S-Type", "X-Type", "XE", "XF", "XJ", "XK"});

                 await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Jeep",
                    new List<string> { "Cherokee", "Commander", "Compass", "Grand Cherokee", "Liberty", "Patriot",
                                        "Renegade", "Wrangler"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Kia",
                    new List<string> { "Carens", "Carnival", "Cee'd", "Cerato", "Clarus", "Joice", "Magentis", "Opirus",
                                        "Optima", "Picanto", "Pride", "Pro_cee'd", "Retona", "Rio", "Shuma", "Sorento",
                                        "Soul", "Sportage", "Venga"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Lamborghini",
                    new List<string> { "Aventador", "Gallardo", "Huracan"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Lancia",
                    new List<string> { "Dedra", "Delta", "Kappa", "Lybra", "Musa", "Phedra", "Thema", "Thesis", "Ypsilon",
                                        "Zeta"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Land Rover",
                    new List<string> { "Defender", "Discovery", "Discovery Sport", "Freelander", "Range Rover",
                                        "Range Rover Evoque", "Range Rover Sport"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Lexus",
                    new List<string> { "CT", "ES", "GS", "GX", "IS", "LS", "LX", "NX", "RC", "RX", "SC"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Maserati",
                    new List<string> { "Ghibli", "GranTurismo", "Quattroporte" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Mazda",
                    new List<string> { "2", "3", "5", "6", "121", "323", "323F", "626", "BT-50", "CX-3", "CX-5",
                                        "CX-7", "CX-9", "Demio", "MPV", "MX-3", "MX-5", "MX-6", "Premacy", "RX-7",
                                        "RX-8", "Seria B", "Tribute", "Xedos"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Mercedes-Benz",
                    new List<string> { "Klasa A", "Klasa B", "Klasa C", "Klasa E", "Klasa G", "Klasa R", "Klasa S", "Klasa V",
                                        "CL", "CLA", "CLC", "CLK", "CLS", "GL", "GLA", "GLC", "GLE", "GLS", "ML", "SL",
                                        "SLC", "SLK", "AMG GT", "Citan", "Sprinter", "Vaneo", "Vito", "W123", "W124",
                                        "W201"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Mini",
                    new List<string> { "1000", "1300", "Clubman", "Cooper", "Cooper S", "Countryman", "ONE", "Paceman"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Mitsubishi",
                    new List<string> { "3000GT", "ASX", "Carisma", "Colt", "Eclipse", "Galant", "Grandis", "L200", "Lancer",
                                        "Lancer Evolution", "Outlander", "Pajero", "Pajero Pinin", "Sigma", "Spacer Gear",
                                        "Space Runner", "Space Star", "Space Wagon", "i-MiEV"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Nissan",
                    new List<string> { "Almera", "Almera Tino", "GT-R", "Juke", "Maxima", "Micra", "Murano", "Navara",
                                        "Note", "Pathfinder", "Patrol", "Pixo", "Primastar", "Primera", "Pulsar",
                                        "Qashqai", "Qashqai+2", "Quest", "Terrano", "Tiida", "X-Trail"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Opel",
                    new List<string> { "Agila", "Antara", "Astra", "Combo", "Corsa", "Frontera", "Insignia", "Karl", "Meriva",
                                        "Mokka", "Movano", "Omega", "Signum", "Tigra", "Vectra", "Vivaro", "Zafira"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Peugeot",
                    new List<string> { "106", "107", "108", "205", "206", "206 CC", "206 plus", "207", "207 CC", "208",
                                        "301", "306", "307", "307 CC", "308", "308 CC", "309", "405", "406", "407",
                                        "508", "605", "607", "806", "807", "1007", "2008", "4007", "4008", "5008",
                                        "Bipper", "Boxer", "Expert", "Partner", "RCZ"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Polonez",
                    new List<string> { "1.5", "1.6", "Atu", "Atu Plus", "Caro", "Caro Plus"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Porsche",
                    new List<string> { "911", "924", "928", "944", "Boxster", "Cayenne", "Cayman", "Macan", "Panamera"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Renault",
                    new List<string> { "5", "Kadjar", "Captur", "Clio", "Espace", "Fluence", "Grand Espace", "Kangoo", "Koleos",
                                        "Laguna", "Latitude", "Master", "Megane", "Modus", "Safrane", "Scenic", "Scenic RX4",
                                        "Talisman", "Thalia", "Trafic", "Twingo", "Vel Satis", "Wind"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Rolls-Royce",
                    new List<string> { "Phantom" });

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Rover",
                    new List<string> { "25", "45", "75", "200", "214", "216", "220", "400", "414", "416", "420", "600",
                                        "618", "620", "820", "827"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Saab",
                    new List<string> { "9-3", "9-5", "900", "9000"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Seat",
                    new List<string> { "Alhambra", "Altea", "Altea XL", "Arosa", "Ateca", "Cordoba", "Exeo", "Ibiza",
                                        "Inca", "Leon", "Marbella", "Mii", "Toledo"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Skoda",
                    new List<string> { "Citigo", "Fabia", "Favorit", "Felicia", "Octavia", "Praktik", "Rapid", "Roomster",
                                        "Superb", "Yeti"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Smart",
                    new List<string> { "Forfour", "Fortwo", "Roadster"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Subaru",
                    new List<string> { "B9 Tribeca", "BRZ", "Forester", "Impreza", "Justy", "Legacy", "Levorg", "Outback",
                                        "Tribeca", "WRX", "XV"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Suzuki",
                    new List<string> { "Alto", "Baleno", "Celerio", "Grand Vitara", "Ignis", "Jimmy", "Kizashi", "Liana",
                                        "SX4", "SX4 S-Cross", "Samurai", "Splash", "Swift", "Vitara", "Wagon R+", "XL7"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Toyota",
                    new List<string> { "4-Runner", "Auris", "Avalon", "Avensis", "Avensis Verso", "Aygo", "Camry", "Carina",
                                        "Celica", "Corolla", "Corolla Verso", "GT86", "Highlander", "Hilux", "Land Cruiser",
                                        "MR2", "Matrix", "Paseo", "Picnic", "Previa", "Prius", "RAV4", "Sienna", "Starlet",
                                        "Supra", "Tacoma", "Verso", "Verso-S", "Yaris", "Yaris Verso", "iQ"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Volkswagen",
                    new List<string> { "Amarok", "Beetle", "Bora", "CC", "Caddy", "Caravelle", "Corrado", "Eos", "Garbus",
                                        "Golf", "Golf Plus", "Golf Sportsvan", "Jetta", "Lupo", "Multivan", "New Beetle",
                                        "Passat", "Passat CC", "Phaeton", "Polo", "Scirocco", "Sharan", "Tiguan", "Touareg",
                                        "Touran", "Tranposrter", "Vento", "up!"});

                await _createListofVehicleModelForGivenBrandAndAddThemToDatabase(
                    "Volvo",
                    new List<string> { "C30", "C70", "S40", "S60", "S70", "S80", "S90", "V40", "V50", "V60", "V70", "XC 60",
                                        "XC 70", "XC 90", "Seria 200", "Seria 300", "Seria 400", "Seria 700", "Seria 900",
                                        "850"});
            }

            //Create vehicle equipment

            if (!_context.VehicleEquipments.Any())
            {
                var equipment = new List<VehicleEquipment>
                {
                    new VehicleEquipment { Name = "ABS"},
                    new VehicleEquipment { Name = "Alarm"},
                    new VehicleEquipment { Name = "Kontrola trakcji (ASR)"},
                    new VehicleEquipment { Name = "Asystent parkowania"},
                    new VehicleEquipment { Name = "Asystent pasa ruchu"},
                    new VehicleEquipment { Name = "Centralny zamek"},
                    new VehicleEquipment { Name = "Czujnik deszczu"},
                    new VehicleEquipment { Name = "Czujnik martwego pola"},
                    new VehicleEquipment { Name = "Czujnik zmierzchu"},
                    new VehicleEquipment { Name = "Czujniki parkowania tylne"},
                    new VehicleEquipment { Name = "Czujniki parkowania przednie"},
                    new VehicleEquipment { Name = "Stabilizacja toru jazdy (ESP)"},
                    new VehicleEquipment { Name = "Immobilizer"},
                    new VehicleEquipment { Name = "Isofix"},
                    new VehicleEquipment { Name = "Kamera cofania"},
                    new VehicleEquipment { Name = "Kurtyny powietrzne"},
                    new VehicleEquipment { Name = "Poduszka powietrzna kierowcy"},
                    new VehicleEquipment { Name = "Poduszka powietrzna pasażera"},
                    new VehicleEquipment { Name = "Poduszki boczne przednie"},
                    new VehicleEquipment { Name = "Światła do jazdy dziennej"},
                    new VehicleEquipment { Name = "Elektryczne szyby"},
                    new VehicleEquipment { Name = "Klimatyzacja"},
                    new VehicleEquipment { Name = "Podgrzewane lusterka boczne"},
                    new VehicleEquipment { Name = "Podgrzewane przednie fotele"},
                    new VehicleEquipment { Name = "Podgrzewane tylne fotele"},
                    new VehicleEquipment { Name = "Wielofunkcyjna kierownica"},
                    new VehicleEquipment { Name = "Wspomaganie kierownicy"},
                    new VehicleEquipment { Name = "Gniazdo AUX"},
                    new VehicleEquipment { Name = "Gniazdo USB"},
                    new VehicleEquipment { Name = "Nawigacja GPS"},
                    new VehicleEquipment { Name = "Alufelgi"},
                    new VehicleEquipment { Name = "Komputer pokładowy"},
                    new VehicleEquipment { Name = "Relingi dachowe"},
                    new VehicleEquipment { Name = "Tempomat"},
                    new VehicleEquipment { Name = "System start-stop"},
                    new VehicleEquipment { Name = "Łopatki zmiany biegów"},
                };

                _context.VehicleEquipments.AddRange(equipment);
                await _context.SaveChangesAsync();
            }

            //Create admin and test users

            if (await _userManager.FindByEmailAsync("matix001@o2.pl") == null)
            {
                CMUser user = new CMUser
                {
                    UserName = "Admin",
                    Email = "matix001@o2.pl",
                    Demographics = _createDemographicsForGivenCityAndProvinceAndAddToTheDatabase("Bydgoszcz", "kujawsko-pomorskie")
                };

                await _userManager.CreateAsync(user, "admin123");

                string[] cities = { "Toruń", "Warszawa", "Kraków", "Poznań", "Łódź" };
                string[] provinces = { "kujawsko-pomorskie", "mazowieckie", "małopolskie", "wielkopolskie", "łódzkie" };

                for (int i = 0; i < 5; i++)
                {
                    CMUser testUser = new CMUser
                    {
                        UserName = "Testowy" + i,
                        Email = "testowy" + i + "@email.pl",
                        Demographics = _createDemographicsForGivenCityAndProvinceAndAddToTheDatabase(cities[i], provinces[i])
                    };

                    await _userManager.CreateAsync(testUser, "testowy123");
                }
            }

            //Create sample offers

            if (!_context.Offers.Any())
            {
                var offers = new List<Offer>
                {
                    new Offer
                    {
                        DateAdded = DateTime.Now,
                        DateFinished = DateTime.Now + TimeSpan.FromDays(100),
                        Title = "Mazda RX-8 Jedyna taka OKAZJA",
                        Price = 15000,
                        Description = "Kupiona w polskim salonie użytkowana przez starszą osobę tylko w niedzielę do kościoła. Niepalone w środku, dziadek płakał jak sprzedawał.",
                        User = await _userManager.FindByNameAsync("Admin"),
                        Vehicle = new Vehicle
                        {
                            Model = _context.VehicleModels.Where(vm => vm.Name == "RX-8").FirstOrDefault(),
                            isDamaged = false,
                            isRegistered = false,
                            EngineCapacity = 1300,
                            Mileage = 157000,
                            ProductionYear = 2005,
                        },
                    },
                    new Offer
                    {
                        DateAdded = DateTime.Now,
                        DateFinished = DateTime.Now + TimeSpan.FromDays(100),
                        Title = "Subaru Impreza STI POTWÓR!!",
                        Price = 45000,
                        Description = "Dużo o samym samochodzie pisać nie trzeba, niesamowite przyspieszenie, legendarny napęd na 4x4. Nikt nie przejdzie wokół niego obojętnie!",
                        User = await _userManager.FindByNameAsync("Admin"),
                        Vehicle = new Vehicle
                        {
                            Model = _context.VehicleModels.Where(vm => vm.Name == "Impreza").FirstOrDefault(),
                            isDamaged = false,
                            isRegistered = false,
                            EngineCapacity = 2500,
                            Mileage = 15000,
                            ProductionYear = 2011,
                            Offer = _context.Offers.Where(o => o.Price == 45000).FirstOrDefault(),
                        },
                    },
                    new Offer
                    {
                        DateAdded = DateTime.Now,
                        DateFinished = DateTime.Now + TimeSpan.FromDays(100),
                        Title = "VW PASSAT 50k 2000 rok",
                        Price = 17599,
                        Description = "Tylko 50 tysięcy przebiegu, stan jak nowy, niezniszczalny silnik 1.9 tdi!",
                        User = await _userManager.FindByNameAsync("Testowy0"),
                        Vehicle = new Vehicle
                        {
                            Model = _context.VehicleModels.Where(vm => vm.Name == "Passat").FirstOrDefault(),
                            isDamaged = false,
                            isRegistered = false,
                            EngineCapacity = 1900,
                            Mileage = 50000,
                            ProductionYear = 2000,
                            Offer = _context.Offers.Where(o => o.Price == 17599).FirstOrDefault(),
                        },
                    },
                    new Offer
                    {
                        DateAdded = DateTime.Now,
                        DateFinished = DateTime.Now + TimeSpan.FromDays(100),
                        Title = "Golf 5 GTI 266 HP",
                        Price = 27000,
                        Description = "Volskwagen Golf w wersji GTI, niepozorny ale ma kopa.",
                        User = await _userManager.FindByNameAsync("Testowy0"),
                        Vehicle = new Vehicle
                        {
                            Model = _context.VehicleModels.Where(vm => vm.Name == "Golf").FirstOrDefault(),
                            isDamaged = false,
                            isRegistered = false,
                            EngineCapacity = 2000,
                            Mileage = 57000,
                            ProductionYear = 2009,
                            Offer = _context.Offers.Where(o => o.Price == 27000).FirstOrDefault(),
                        },

                    },
                };




                _context.Offers.AddRange(offers);
                await _context.SaveChangesAsync();

            }


            // Create sample equipment for vehicles

            if (!_context.VehicleVehicleEquipment.Any())
            {
                var vehicles = _context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    var vehicleEquipment = new VehicleVehicleEquipment
                    {
                        Equipment = _context
                            .VehicleEquipments
                            .Where(ve => ve.Name == "Klimatyzacja")
                            .FirstOrDefault(),
                        Vehicle = vehicle
                    };

                    _context.VehicleVehicleEquipment.Add(vehicleEquipment);
                    await _context.SaveChangesAsync();
                }
            }
        }


        
        private async Task _createListofVehicleModelForGivenBrandAndAddThemToDatabase(string brandName, List<string> modelNames)
        {
            var brand = _context.VehicleBrands
                    .Where(v => v.Name.Equals(brandName))
                    .FirstOrDefault();

            List<VehicleModel> models = new List<VehicleModel>();

            foreach (string modelName in modelNames)
            {
                models.Add(new VehicleModel { Brand = brand, Name = modelName });
            }

            _context.VehicleModels.AddRange(models);
            await _context.SaveChangesAsync();
        }

        private Demographics _createDemographicsForGivenCityAndProvinceAndAddToTheDatabase(string city, string province)
        {
            Demographics demographics = new Demographics
            {
                City = city,
                Province = _context
                    .Provinces
                    .Where(p => p.Name == province)
                    .FirstOrDefault()
            };

            _context.Demographics.Add(demographics);
            _context.SaveChanges();

            return demographics;
        }
    }
}
