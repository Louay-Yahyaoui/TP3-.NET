using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using tp2.Models;

namespace tp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            Debug.WriteLine("Home");
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\Louay\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();
            using(dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info",dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstname = (string)reader["first_name"];
                        string lastname = (string)reader["last_name"];
                        string email = (string)reader["email"];
             
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("id:{0},first name:{1},last name:{2},email:{3},image:{4},country:{5} ", id,firstname,lastname,email,image,country);
                    }

                }
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}