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
            Computer myComputer = new Computer()
            {
                Motherboard = "Z690x",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 2943.87m,
                VideoCard = "RTX 2060x"
            };

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

            File.WriteAllText("log.txt", "\n" + sql + "\n");

            using StreamWriter openFile = new("log.txt", append: true);

            openFile.WriteLine("\n" + sql + "\n");

            openFile.Close();

            Console.WriteLine(File.ReadAllText("log.txt"));
        }
    }
}