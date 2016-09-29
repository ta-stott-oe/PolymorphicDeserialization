using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymorphicDeserializationExample.Models.Vehicles
{
    public class VehicleConverter : EnumSwitchJsonConverter<VehicleType, Vehicle>
    {
        private static readonly IDictionary<VehicleType, Type> mappings = new Dictionary<VehicleType, Type>
        {
            [VehicleType.Bicycle] = typeof(Bicycle),
            [VehicleType.Car] = typeof(Car)
        };

        public VehicleConverter()
            : base("Type", mappings) { }
    }
}