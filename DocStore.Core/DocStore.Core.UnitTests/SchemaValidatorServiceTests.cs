using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DocStore.Core.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DocStore.Core.UnitTests
{
    public class Person
    {
        [Required] public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required] public string LastName { get; set; }

        public Gender Gender { get; set; }

        [System.ComponentModel.DataAnnotations.Range(2, 5)]
        public int NumberWithRange { get; set; }

        public DateTime Birthday { get; set; }

        public Company Company { get; set; }

        public Collection<Car> Cars { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Car
    {
        public string Name { get; set; }

        public Company Manufacturer { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
    }

    public class SchemaValidatorServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Service__BuildSchema1()
        {
            // arrange
            var service = new SchemaValidatorService();

            // act
            var schema = service.GetSchemaFromType<Person>();

            // assert
            Assert.IsTrue(schema != null);
        }

        [Test]
        public void Service__ValidateSchema__ValidCase()
        {
            // arrange
            var service = new SchemaValidatorService();
            var schema = service.GetSchemaFromType<Person>();

            var person = new Person();
            person.Birthday = DateTime.Now;
            person.Company = new Company();
            person.Company.Name = "Foo Inc";
            person.FirstName = "Sarah";
            person.LastName = "Rosario";
            person.Gender = Gender.Female;
            person.NumberWithRange = 3;

            var jsonString = JsonConvert.SerializeObject(person);

            // act
            var errors = service.Validate(schema, jsonString);

            // assert
            Console.WriteLine(JsonConvert.SerializeObject(errors));
            Assert.IsTrue(errors.Count == 0);
        }

        [Test]
        public void Service__ValidateSchema__FailWhenFirstNameMissing()
        {
            // arrange
            var service = new SchemaValidatorService();
            var schema = service.GetSchemaFromType<Person>();

            var person = new Person();
            person.Birthday = DateTime.Now;
            person.Company = new Company();
            person.Company.Name = "Foo Inc";
            person.FirstName = "";
            person.LastName = "Rosario";
            person.Gender = Gender.Female;
            person.NumberWithRange = 3;

            var jsonString = JsonConvert.SerializeObject(person);

            // act
            var errors = service.Validate(schema, jsonString);

            // assert
            Console.WriteLine(JsonConvert.SerializeObject(errors));
            Assert.IsTrue(errors.Count == 1);
        }


        [Test]
        public async Task Service__BuildSchemaFromString()
        {
            // arrange
            var service = new SchemaValidatorService();
            var schema = service.GetSchemaFromType<Person>();
            var schemaString = schema.ToJson();

            // act
            var schema2 = await service.GetSchemaFromJsonAsync(schemaString);

            // assert
            Assert.IsTrue(schema2 != null);
        }
    }
}