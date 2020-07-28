using Xunit;
using CommandDotNet.Rendering;
using System.Collections.Generic;
using CommandDotNet;
using CommandDotNet.FluentValidation;
using CommandDotNet.TestTools.Scenarios;
using System.Linq;
using Moq;
using CliApp.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace CliApp.Tests
{
    public class RepositoryTest
    {
        private readonly IRepository repository;
        public RepositoryTest()
        {
            repository = GetInMemoryPersonRepository();
            var person1 = new Person { FirstName = "Mark", LastName = "Johnson" };
            var person2 = new Person { FirstName = "John", LastName = "Doe" };
            repository.Add<Person>(person1);
            repository.Add<Person>(person2);


            var address1 = new Address { Id = 1, City = "Dublin", Person = person1, PersonId = person1.Id, PostalCode = "XY123", Street = "Street1", State = "Dublin" };
            var address2 = new Address { Id = 2, City = "Chicago", Person = person1, PersonId = person1.Id, PostalCode = "XY123", Street = "Street2", State = "Illinois" };
            repository.Add<Address>(address1);
            repository.Add<Address>(address2);

        }

        [Fact]
        public void Test_GetPersonById()
        {
            var person = repository.GetById<Person>(1);

            Assert.Equal("Mark", person.FirstName);
        }

        [Fact]
        public void Test_DeletePerson()
        {
            var person1 = new Person { FirstName = "Jack", LastName = "Doe" };
            repository.Add<Person>(person1);
            var person = repository.GetById<Person>(3);


            repository.Delete<Person>(person);
            int count = repository.List<Person>().Count;


            Assert.Equal(2, count);
        }

        [Fact]
        public void Test_ModifyPerson()
        {
            var person = repository.GetById<Person>(1);
            person.FirstName = "Anthony";
            person.LastName = "Wiggins";
            repository.Update<Person>(person);


            Assert.Equal("Anthony", repository.GetById<Person>(1).FirstName);

        }

        [Fact]
        public void Test_CorrectNumberOfAddressesAdded()
        {

            var person = repository.GetById<Person>(1);

            Assert.Equal(2, person.Adresses.Count());

        }

        [Fact]
        public void Test_ModifyAddress()
        {
            var address = repository.GetById<Address>(1);
            address.Street = "Street2";
            repository.Update<Address>(address);

            address = repository.GetById<Address>(1);
            Assert.Equal("Street2", address.Street);

        }

        [Fact]
        public void Test_CountPersons()
        {
            int count = repository.List<Person>().Count;

            Assert.Equal(2, count);
        }

        private IRepository GetInMemoryPersonRepository()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: "TempDb");

            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();
            return new EfRepository(appDbContext);
        }
    }
}
