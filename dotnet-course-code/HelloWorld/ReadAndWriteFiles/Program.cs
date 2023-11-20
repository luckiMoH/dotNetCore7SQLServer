using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Data;
using Models.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text.Json;

namespace HelloWorld
{


    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            //Computer myComputer = new Computer()
            //{
            //    Motherboard = "Z690x",
            //    HasWifi = true,
            //    HasLTE = false,
            //    ReleaseDate = DateTime.Now,
            //    Price = 2943.87m,
            //    VideoCard = "RTX 2060x"
            //};

            //string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //    Motherboard,
            //    HasWifi,
            //    HasLTE,
            //    ReleaseDate,
            //    Price,
            //    VideoCard
            //) VALUES ('" + myComputer.Motherboard
            //   + "','" + myComputer.HasWifi
            //   + "','" + myComputer.HasLTE
            //   + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //   + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
            //   + "','" + myComputer.VideoCard
            //+ "')";

            //File.WriteAllText("log.txt", "\n" + sql + "\n");

            //using StreamWriter openFile = new("log.txt", append: true);

            //openFile.WriteLine("\n" + sql + "\n");

            //openFile.Close();

            //string computersJson = File.ReadAllText("Computers.json"); // czytanie Computers.json file ktory jest w bin
            string computersJson = File.ReadAllText("ComputersSnake.json"); // czytanie Computers.json file ktory jest w bin

            Mapper mapper = new Mapper(new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<ComputerSnake, Computer>()
                .ForMember(destination => destination.ComputerId, options =>
                    options.MapFrom(source => source.computer_id))
                .ForMember(destination => destination.CPUCores, options =>
                    options.MapFrom(source => source.cpu_cores))
                .ForMember(destination => destination.HasLTE, options =>
                    options.MapFrom(source => source.has_lte))
                .ForMember(destination => destination.HasWifi, options =>
                    options.MapFrom(source => source.has_wifi))
                .ForMember(destination => destination.Motherboard, options =>
                    options.MapFrom(source => source.motherboard))
                .ForMember(destination => destination.VideoCard, options =>
                    options.MapFrom(source => source.video_card))
                .ForMember(destination => destination.ReleaseDate, options =>
                    options.MapFrom(source => source.release_date))
                .ForMember(destination => destination.Price, options =>
                    options.MapFrom(source => source.price));
            }));

            IEnumerable<Computer>? computersSystemJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson); // tworzenie listy z pliku json korzystając z System.Text.Json, musimy uzyć options zeby bylo case sensitive
            if (computersSystemJsonPropertyMapping != null)
            {
                Console.WriteLine(computersSystemJsonPropertyMapping.Count());
                foreach (Computer computer in computersSystemJsonPropertyMapping)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }


            IEnumerable<ComputerSnake>? computersSystemAutoMapper = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson); // tworzenie listy z pliku json korzystając z System.Text.Json, musimy uzyć options zeby bylo case sensitive

            if (computersSystemAutoMapper != null)
            {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystemAutoMapper);
                Console.WriteLine(computerResult.Count());
                foreach (Computer computer in computerResult)
                {
                    Console.WriteLine(computer.ReleaseDate);
                }
            }

            //Console.WriteLine(computersJson);

            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //};

            //IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson); // tworzenie listy z pliku json z paczka Newtonsoft.Json
            //IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options); // tworzenie listy z pliku json korzystając z System.Text.Json, musimy uzyć options zeby bylo case sensitive

            //if (computersNewtonsoft != null)
            //{
            //    foreach (Computer computer in computersNewtonsoft)
            //    {
            //        //Console.WriteLine(computer.Motherboard);
            //        string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //    Motherboard,
            //    HasWifi,
            //    HasLTE,
            //    ReleaseDate,
            //    Price,
            //    VideoCard
            //) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
            //   + "','" + computer.HasWifi
            //   + "','" + computer.HasLTE
            //   + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd")
            //   + "','" + computer.Price.ToString("0.00", CultureInfo.InvariantCulture)
            //   + "','" + EscapeSingleQuote(computer.VideoCard)
            //+ "')";

            //        dapper.ExecuteSql(sql);
            //    }
            //}

            //JsonSerializerSettings settings = new JsonSerializerSettings() // w Newtonsoft jak chcemy serializowac do pierwotnej formy musimy uzyc tych settingsow
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};

            //string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);
            //File.WriteAllText("computersCopyNewtonsoft.txt", "\n" + computersCopyNewtonsoft + "\n");

            //string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            //File.WriteAllText("computersCopySystem.txt", "\n" + computersCopySystem + "\n");
        }

        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");

            return output;
        }
    }
}