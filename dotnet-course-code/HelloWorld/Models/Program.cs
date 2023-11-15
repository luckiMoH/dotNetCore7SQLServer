using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Data;
using Models.Models;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace HelloWorld
{

   
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dataContextDapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690x",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 2943.87m,
                VideoCard = "RTX 2060x"
            };

            //entityFramework.Add(myComputer); //dodawanie wartości do bazy danych
            //entityFramework.SaveChanges(); //zapisywanie zmian

            Console.WriteLine(myComputer.Price); // comma jako separator
            Console.WriteLine(myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)); // zamiana comma na dot jako separator

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard 
               + "','" + myComputer.HasWifi 
               + "','" + myComputer.HasLTE 
               + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
               + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
               + "','" + myComputer.VideoCard
            + "')";

            //Console.WriteLine(sql);

            //int result = dataContextDapper.ExecuteSqlWithRowCount(sql); // dodawanie wartości do bazy danych na podstawie stworzonego SQL Query sql
            //bool result = dataContextDapper.ExecuteSql(sql); // dodawanie wartości do bazy danych na podstawie stworzonego SQL Query sql
            //Console.WriteLine(result);

            string sqlSelect = @"
            SELECT 
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
               FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(sqlSelect); // wyciąganie IEnumerable(kolekcji) z bazy danych

            Console.WriteLine("Tutaj są dane przesłane z bazy danych Dapper");

            foreach (Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.ComputerId
               + "','" + singleComputer.Motherboard
               + "','" + singleComputer.HasWifi
               + "','" + singleComputer.HasLTE
               + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
               + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
               + "','" + singleComputer.VideoCard
            + "'");
            }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>(); // wyciąganie IEnumerable(kolekcji) z bazy danych

            Console.WriteLine("Tutaj są dane przesłane z bazy danych EF");

            if (computersEf != null)
            {
                foreach (Computer singleComputer in computersEf)
                {
                    Console.WriteLine("'" + singleComputer.ComputerId
                   + "','" + singleComputer.Motherboard
                   + "','" + singleComputer.HasWifi
                   + "','" + singleComputer.HasLTE
                   + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                   + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                   + "','" + singleComputer.VideoCard
                + "'");
                }
            }


            //myComputer.HasWifi = false;
            //Console.WriteLine(myComputer.Price);
            //Console.WriteLine(myComputer.HasWifi);
            //Console.WriteLine(myComputer.ReleaseDate);
        }
    }
}