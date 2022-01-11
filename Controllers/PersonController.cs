using Allied_Testing_App.Models;
using Allied_Testing_App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Allied_Testing_App.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        public PersonController() { }

        [HttpGet]
        public ActionResult<List<Person>> GetAll() =>
            PersonService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = PersonService.Get(id);

            if (person is null)
                return NotFound();

            return person;
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!AddressService.GetAll().Contains(person.address))
                AddressService.Add(person.address);
            PersonService.Add(person);
            return CreatedAtAction(nameof(Create), new { id = person.id }, person);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            if (id != person.id)
                return BadRequest();
            var existingperson = PersonService.Get(id);
            if (existingperson is null)
                return NotFound();

            if (!AddressService.GetAll().Contains(person.address))
                AddressService.Add(person.address);
            PersonService.Update(person);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = PersonService.Get(id);

            if (person is null)
                return NotFound();
            PersonService.Delete(id);

            return NoContent();
        }
    }
}
