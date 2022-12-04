using System.Data.Entity.Core.Objects;

namespace tp2.Models
{
   
    public class Person
    {
        
        public int id;
        public string? firstname  { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }

        public string? image { get; set; }
        public string? country { get; set; }
        public Person(int id, string firstname,string lastname,string email,string image,string country)
        {
            
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.country = country;
            this.image = image;
        }
    }
}