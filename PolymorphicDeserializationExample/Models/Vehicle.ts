


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

	
    export interface Vehicle {
        
        // TYPE
        Type: VehicleType;
		
    }

    
    export interface Bicycle extends Vehicle {
        
        // NUMBEROFGEARSBACK
        NumberOfGearsBack: number;
		
        // NUMBEROFGEARSFRONT
        NumberOfGearsFront: number;
		
    }
    export interface Car extends Vehicle {
        
        // ENGINETYPE
        EngineType: EngineType;
		
    }

	
	export type VehicleType =
		
			"Bicycle"
		|
			"Car"
		
	
	export const VehicleType = {
		Bicycle: "Bicycle" as VehicleType,
		Car: "Car" as VehicleType,
		
	}

	export type EngineType =
		
			"Petrol"
		|
			"Diesel"
		|
			"Electric"
		
	
	export const EngineType = {
		Petrol: "Petrol" as EngineType,
		Diesel: "Diesel" as EngineType,
		Electric: "Electric" as EngineType,
		
	}

    EngineType.Diesel