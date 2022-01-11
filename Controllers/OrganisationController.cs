using Allied_Testing_App.Models;
using Allied_Testing_App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Allied_Testing_App.Controllers
{
    [ApiController]
    [Route("Organisation")]
    public class OrganisationController : ControllerBase
    {
        public OrganisationController() { }

        [HttpGet]
        public ActionResult<List<Organisation>> GetAll() =>
            OrganisationService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Organisation> Get(int id)
        {
            var organisation = OrganisationService.Get(id);

            if (organisation is null)
                return NotFound();

            return organisation;
        }
        [HttpPost]
        public IActionResult Create(Organisation organisation)
        {
            if (!AddressService.GetAll().Contains(organisation.address))
                AddressService.Add(organisation.address);
            OrganisationService.Add(organisation);
            return CreatedAtAction(nameof(Create), new { id = organisation.id }, organisation);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Organisation organisation)
        {
            if (id != organisation.id)
                return BadRequest();

            var existingorg = OrganisationService.Get(id);
            if (existingorg is null)
                return NotFound();

            if (!AddressService.GetAll().Contains(organisation.address))
                AddressService.Add(organisation.address);
            OrganisationService.Update(organisation);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var organisation = OrganisationService.Get(id);
            if (organisation is null)
                return NotFound();
            OrganisationService.Delete(id);

            return NoContent();
        }

    }
}