using Dapper;
using Microsoft.Data.SqlClient;
using Models.Models;
using System.Data;
using System.Globalization;

namespace HelloWorld
{

   
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

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

            int result = dbConnection.Execute(sql); // dodawanie wartości do bazy danych na podstawie stworzonego SQL Query sql
            //Console.WriteLine(result);

            string sqlSelect = @"
            SELECT 
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
               FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

            Console.WriteLine("Tutaj są dane przesłane z bazy danych");

            foreach (Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.Motherboard
               + "','" + singleComputer.HasWifi
               + "','" + singleComputer.HasLTE
               + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
               + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
               + "','" + singleComputer.VideoCard
            + "'");
            }

            //myComputer.HasWifi = false;
            //Console.WriteLine(myComputer.Price);
            //Console.WriteLine(myComputer.HasWifi);
            //Console.WriteLine(myComputer.ReleaseDate);
        }
    }
}