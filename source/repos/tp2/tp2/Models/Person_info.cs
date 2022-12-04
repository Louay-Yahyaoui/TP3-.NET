using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace tp2.Models
{
    public class Person_info
    {

        public static List<Person>? persons = GetAllPerson();
        public static List<Person> GetAllPerson()
        {
            List<Person> persons = new List<Person>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\Louay\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        persons.Add(new Person((int)reader["id"], (string)reader["first_name"], (string)reader["last_name"], (string)reader["email"], (string)reader["image"], (string)reader["country"]));
                    }
                }
                return persons;
            }
        }
        public static Person? GetPerson(int id)
        {
            Person? person = null;
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\Louay\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info where id="+id, dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        person = new Person((int)reader["id"], (string)reader["first_name"], (string)reader["last_name"], (string)reader["email"], (string)reader["image"], (string)reader["country"]);
                    }
                }
                return person;
            }

        }
    }
}