


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

	
    export abstract class Vehicle {
		constructor(public Type: VehicleType){
		}
    }

    
    export class Bicycle extends Vehicle {
        constructor(public NumberOfGearsBack: number, public NumberOfGearsFront: number){
			super(VehicleType.Bicycle);
		}
    }
    export class Car extends Vehicle {
        constructor(public EngineType: EngineType){
			super(VehicleType.Car);
		}
    }

	
	export type VehicleType =
		"Bicycle" |
		"Car"
	
	export const VehicleType = {
		Bicycle: "Bicycle" as VehicleType,
		Car: "Car" as VehicleType
	}

	export type EngineType =
		"Petrol" |
		"Diesel" |
		"Electric"
	
	export const EngineType = {
		Petrol: "Petrol" as EngineType,
		Diesel: "Diesel" as EngineType,
		Electric: "Electric" as EngineType
	}

