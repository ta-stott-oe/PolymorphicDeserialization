using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymorphicDeserializationExample.Models
{
    public class VehicleConverter : JsonCreationConverter<Vehicle>
    {
        protected override Type GetTargetType(Vehicle baseObject)
        {
            switch (baseObject.Type)
            {
                case VehicleType.Bicycle: return typeof(Bicycle);
                case VehicleType.Car: return typeof(Car);
                default: throw new Exception($"Unrecognized vehicle type: '{baseObject.Type}'");
            }
        }
    }
}