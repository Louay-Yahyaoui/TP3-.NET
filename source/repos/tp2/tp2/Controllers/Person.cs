using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp2.Models;

namespace tp2.Controllers
{
    public class Person: Controller
    {
        [Route("Person/{id:int}")]
        public IActionResult ById(int id)
        {
            return View(Person_info.GetPerson(id));
        }
        public IActionResult all()
        {
            return View(new Person_info());
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string firstname,string country)
        {
            List<Models.Person> Persons=Person_info.GetAllPerson();
            Debug.WriteLine(firstname+country);
            foreach (Models.Person person in Persons)
            {
                if ((person.firstname == firstname) && (person.country == country))
                {
                    return Redirect("/Person/" + person.id);
                }
            }
            ViewBag.Firstname = firstname;
            ViewBag.Country = country;
            return View();
        }
    }
}
