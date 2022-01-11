using Allied_Testing_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Allied_Testing_App.Services
{
    public static class PersonService
    {   
        static List<Person> people { get; }
        static int nextId = 4;
        static PersonService()
        {
            people = new List<Person>
            {
                new Person
                {
                    id = 1,
                    firstName = "Maxim",
                    lastName = "Gonciarov",
                    email = "huzaahapt@gmail.com",
                    address = AddressService.Get(1)
                },
                new Person
                {
                    id = 2,
                    firstName = "Ludmila",
                    lastName = "Dovbenco",
                    email = "ldovbenco@alliedtesting.com",
                    address = AddressService.Get(2)
                },
                new Person
                {
                    id = 3,
                    firstName = "Stas",
                    lastName = "Milev",
                    email = "stas.milev@alliedtesting.com",
                    address = AddressService.Get(3)
                }
            };
        }

        public static List<Person> GetAll() => people;
        public static Person? Get(int id) => people.FirstOrDefault(a => a.id == id);
        public static void Add(Person person)
        {
            person.id = nextId++;
            people.Add(person);
        }
        public static void Delete(int id)
        {
            var person = Get(id);
            if (person is null)
                return;
            people.Remove(person);
        }
        public static void Update(Person person)
        {
            var index = people.FindIndex(p => p.id == person.id);
            if (index == -1)
                return;
            people[index] = person;
        }

    }
}
