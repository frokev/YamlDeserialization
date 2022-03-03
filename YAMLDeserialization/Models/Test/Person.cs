using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlSerialization;

namespace Examples.Models.Test
{
    internal class Person
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public Car Car { get; set; } = new Car();

        public Car SecondCar { get; set; } = new Car();

        public Address? Address { get; set; }

        public List<IHobby>? Hobbies { get; set; }

        public string ToString(ISerializer serializer)
        {
            return serializer.Serialize(this);
        }
    }
}
