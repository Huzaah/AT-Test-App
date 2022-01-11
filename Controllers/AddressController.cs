using Allied_Testing_App.Models;
using Allied_Testing_App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Allied_Testing_App.Controllers
{
    [ApiController]
    [Route("Address")]
    public class AddressController : ControllerBase
    {
        public AddressController() { }

        [HttpGet]
        public ActionResult<List<Address>> GetAll() =>
            AddressService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            var address = AddressService.Get(id);

            if (address is null)
                return NotFound();

            return address;
        }
        [HttpPost]
        public IActionResult Create(Address address)
        {
            AddressService.Add(address);
            return CreatedAtAction(nameof(Create), new { id = address.id }, address);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Address address)
        {
            if (id != address.id)
                return BadRequest();

            var existingaddress = AddressService.Get(id);
            if (existingaddress is null)
                return NotFound();

            AddressService.Update(address);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var address = AddressService.Get(id);

            if (address is null)
                return NotFound();
            AddressService.Delete(id);

            return NoContent();
        }

    }

}
