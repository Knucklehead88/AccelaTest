using CliApp.Command.ArgumentModels;
using CliApp.Core.Repository;
using CommandDotNet;
using System;

namespace CliApp.Command
{
    public class PersonsCli
    {
        private readonly IRepository repository;

        public PersonsCli(IRepository repository)
        {
            this.repository = repository;
        }

        [Command(Name = "list")]
        public void List()
        {
            var persons = repository.List<Person>();

            if (persons.Count == 0)
            {
                Console.WriteLine("There are no people added yet");
            }
            else
            {
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
                }
            }
        }

        [Command(Name = "list_addr")]
        public void ListAddresses()
        {
            var addresses = repository.List<Address>();

            if (addresses.Count == 0)
            {
                Console.WriteLine("There are no addresses added yet");
            }
            else
            {
                foreach (var address in addresses)
                {
                    Console.WriteLine($"{address.Id} {address.PersonId} {address.Street} {address.City}");
                }
            }
        }

        [Command(Name = "count")]
        public void Count()
        {
            var count = repository.List<Person>().Count;
            Console.WriteLine($"There {(count > 1 ? "are" : "is")} {count} {(count > 1 ? "people" : "person")} in the database");
        }

        [Command(Name = "edit")]
        public void Edit(EditPersonArgs args)
        {
            var person = repository.GetById<Person>(args.Person.PersonId);
            if (person == null)
            {
                Console.WriteLine($"The person with id:{args.Person.PersonId} does not exist");
                return;
            }

            if (String.IsNullOrEmpty(args.PersonName.FirstName) && String.IsNullOrEmpty(args.PersonName.LastName))
            {
                Console.WriteLine($"You haven't provided a FirstName or LastName");
                return;
            }

            person.FirstName = args.PersonName.FirstName;
            person.LastName = args.PersonName.LastName;

            repository.Update<Person>(person);

            Console.WriteLine($"The person with id:{person.Id} has been updated");
        }

        [Command(Name = "edit_addr")]
        public void Edit_Address(EditAddressArgs args)
        {
            var address = repository.GetById<Address>(args.Address.AddressId);
            if (address == null)
            {
                Console.WriteLine($"The address with id:{args.Address.AddressId} does not exist");
                return;
            }

            address.Street = args.AddressDetails.Street;
            address.City = args.AddressDetails.City;
            address.PostalCode = args.AddressDetails.PostalCode;
            address.State = args.AddressDetails.State;

            repository.Update<Address>(address);

            Console.WriteLine($"The address with id:{address.Id} has been updated");
        }

        [Command(Name = "delete")]
        public void Delete(PersonIdArgs args)
        {

            var person = repository.GetById<Person>(args.PersonId);
            if (person == null)
            {
                Console.WriteLine($"The person with id:{args.PersonId} does not exist");
                return;
            }

            repository.Delete<Person>(person);
            Console.WriteLine($"The person with id:{person.Id} has been deleted");


        }

        [Command(Name = "delete_addr")]
        public void Delete_Address(AddressIdArgs args)
        {

            var address = repository.GetById<Address>(args.AddressId);
            if (address == null)
            {
                Console.WriteLine($"The address with id:{args.AddressId} does not exist");
                return;
            }

            repository.Delete<Address>(address);
            Console.WriteLine($"The address with id:{args.AddressId} has been deleted");


        }

        [Command(Name = "add")]
        public void Add(PersonNameArgs args)
        {
            repository.Add<Person>(new Person() { FirstName = args.FirstName, LastName = args.LastName });
            Console.WriteLine($"Added a new person");


        }

        [Command(Name = "add_addr")]
        public void Add_Address(PersonIdArgs id, AddressArgs address)
        {
            var person = repository.GetById<Person>(id.PersonId);
            if (person == null)
            {
                Console.WriteLine($"The person with id:{id.PersonId} does not exist");
                return;
            }

            var newAddress = new Address { Street = address.Street, City = address.City, State = address.State, PostalCode = address.PostalCode, Person = person, PersonId = id.PersonId };

            repository.Add<Address>(newAddress);
            Console.WriteLine($"Added a new address");

        }
    }
}
