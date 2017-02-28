using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L3.Models
{
    public class DataManager
    {
        static List<Person> people = new List<Person>()
        {
            new Person { Id = 1, Name = "Ove", Email = "ove.leif@gmail.com"},
            new Person { Id = 2, Name = "Lasse", Email = "luckylasse@hotmail.com"},
        };

        //public static void AddPerson(Person person)
        //{
        //    person.Id = people.Max(p => p.Id) + 1;
        //    people.Add(person);
        //}

        public static void AddPerson(PeopleCreateVM viewModel)
        {
            var person = new Person
            {
                Id = people.Max(p => p.Id) + 1,
                Name = viewModel.Name,
                Email = viewModel.Email
            }; people.Add(person);
        }

        public static PeopleIndexVM[] ListPeople()
        {
            return people.Select(o => new PeopleIndexVM
            {
                Name = o.Name,
                Email = o.Email,
                ShowAsHighLighted = o.Email.EndsWith("@acme.com", StringComparison.OrdinalIgnoreCase)
            })
            .ToArray();
        }

        public static Person[] GetAllPeople()
        {
            return people.ToArray();
        }
    }
}
