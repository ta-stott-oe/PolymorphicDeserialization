using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymorphicDeserializationExample.Models
{
    public enum VehicleType
    {
        Bicycle,
        Car
    }

    public abstract class Vehicle
    {
        public VehicleType Type { get; private set; }

        public Vehicle(VehicleType type)
        {
            this.Type = type;
        }
    }

    public class Bicycle : Vehicle
    { 
        public int NumberOfGearsBack { get; private set; }
        public int NumberOfGearsFront { get; private set; }

        public Bicycle(int numberOfGearsFront, int numberOfGearsBack) : base(VehicleType.Bicycle)
        {
            this.NumberOfGearsFront = numberOfGearsFront;
            this.NumberOfGearsBack = numberOfGearsBack;
        }
    }

    public enum EngineType
    {
        Petrol,
        Diesel,
        Electric
    }


    public class Car : Vehicle
    {
        public EngineType EngineType { get; private set; }

        public Car(EngineType engineType): base(VehicleType.Car)
        {
            this.EngineType = engineType;
        }
    }


}