using Allied_Testing_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Allied_Testing_App.Services
{
    public static class OrganisationService
    { 
        static List<Organisation>   organisations { get; }
        static int nextId = 3;
        static OrganisationService()
        {
            organisations = new List<Organisation>
            {
                new Organisation
                {
                    id = 1,
                    name = "Allied Testing",
                    address = AddressService.Get(1)
                },
                new Organisation
                {
                    id = 2,
                    name = "CEITI",
                    address = AddressService.Get(1)
                }
            };
        }
        public static List<Organisation> GetAll() => organisations;
        public static Organisation? Get(int id) => organisations.FirstOrDefault(o => o.id == id);
        public static void Add(Organisation organisation)
        {
            organisation.id = nextId++;
            organisations.Add(organisation);
        }
        public static void Delete(int id)
        {
            var organisation = Get(id);
            if (organisation is null)
                return;
            organisations.Remove(organisation);
        }
        public static void Update(Organisation organisation)
        {
            var index = organisations.FindIndex(o => o.id == organisation.id);
            if (index == -1)
                return;

            organisations[index] = organisation;
        }
    }
}
