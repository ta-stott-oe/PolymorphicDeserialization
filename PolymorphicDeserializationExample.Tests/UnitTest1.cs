using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PolymorphicDeserializationExample.Models;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace PolymorphicDeserializationExample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json = "[{\"Type\": 0,\"NumberOfGearsFront\": 3,\"NumberOfGearsBack\": 8}, {\"Type\": 1, \"EngineType\": 0}]";
            var items = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(json, new VehicleConverter());

            items.First().Should().BeOfType<Bicycle>();
            items.Skip(1).First().Should().BeOfType<Car>();
        }
    }
}
