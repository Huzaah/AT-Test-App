using Allied_Testing_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Allied_Testing_App.Services
{
    public static class AddressService
    {
        static List<Address> addresses { get; }
        static int nextId = 4;
        static AddressService()
        {
            addresses = new List<Address>
            {
                new Address
                {
                    id = 1,
                    locale = "md",
                    addressLine1 = "Stephen The Great st.",
                    addressLine2 = "",
                    addressLine3 = "",
                    city = "Chishinau",
                    state = "Moldova",
                    postcode = "MD-2000",
                    countryIsoCode = "MDA"
                },
                new Address
                {
                    id = 2,
                    locale = "ru",
                    addressLine1 = "Pushkin st.",
                    addressLine2 = "",
                    addressLine3 = "",
                    city = "Moscow",
                    state = "Russia",
                    postcode = "143350",
                    countryIsoCode = "RUS"
                },
                new Address
                {
                    id = 3,
                    locale = "en",
                    addressLine1 = "Parlament Sq.",
                    addressLine2 = "Westminster",
                    addressLine3 = "",
                    city = "London",
                    state = "England",
                    postcode = "SW1A 0AA",
                    countryIsoCode = "GBR"
                }
            };
        }

        public static List<Address> GetAll() => addresses;
        public static Address? Get(int id) => addresses.FirstOrDefault(a => a.id == id);
        public static void Add(Address address)
        {
            address.id = nextId++;
            addresses.Add(address);
        }

        public static void Delete(int id)
        {
            var address = Get(id);
            if (address is null)
                return;
            addresses.Remove(address);
        }

        public static void Update(Address address)
        {
            var index = addresses.FindIndex(a => a.id == address.id);
            if (index == -1)
                return;

            addresses[index] = address;
        }
    }
}