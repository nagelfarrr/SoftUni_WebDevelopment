function solve(input) {
    const numberOfAstronauts = Number(input.shift());

    class Astronaut {
        constructor(name, oxygenLevel, energyReserves) {
            this.name = name,
            this.oxygenLevel = Number(oxygenLevel),
            this.energyReserves = Number(energyReserves)
        };
    }

    let astronauts = [];


    for (let i = 0; i < numberOfAstronauts; i++) {
        let astronautDetails = input.shift().split(" ");
        let astronautName = astronautDetails[0];
        let astronautOxygen = astronautDetails[1];
        let astronautEnergy = astronautDetails[2];

        let currentAstronaut = new Astronaut(astronautName, astronautOxygen, astronautEnergy);

        astronauts.push(currentAstronaut);
    }

    let commandInput = input.shift();

    while (commandInput != "End") {
        let commandTokens = commandInput.split(" - ");
        let command = commandTokens[0];
        let astronautName = commandTokens[1];
        let amounts = Number(commandTokens[2]);


        let astronaut = getAstronaut(astronautName);
        switch (command) {
            case "Explore":

                if (astronaut.energyReserves >= amounts) {
                    astronaut.energyReserves -= amounts;
                    console.log(`${astronaut.name} has successfully explored a new area and now has ${(astronaut.energyReserves)} energy!`);
                } else {
                    console.log(`${astronaut.name} does not have enough energy to explore!`);
                }
                break;
            case "Refuel":
                let refueledEnergy;
                if (astronaut.energyReserves + amounts > 200) {
                    refueledEnergy = 200 - astronaut.energyReserves;
                    astronaut.energyReserves = 200;
                    console.log(`${astronaut.name} refueled their energy by ${refueledEnergy}!`)
                } else {
                    astronaut.energyReserves += amounts;
                    console.log(`${astronaut.name} refueled their energy by ${amounts}!`)
                }
                break;
            case "Breathe":
                let oxygenReplenished;
                if(astronaut.oxygenLevel + amounts > 100) {
                    oxygenReplenished = 100 - astronaut.oxygenLevel;
                    astronaut.oxygenLevel = 100;
                    console.log(`${astronaut.name} took a breath and recovered ${oxygenReplenished} oxygen!`);
                } else {
                    astronaut.oxygenLevel += amounts;
                    console.log(`${astronaut.name} took a breath and recovered ${amounts} oxygen!`)
                }

                
                break;
            default:
                break;
        }


        commandInput = input.shift();
    }

    astronauts.forEach(astronaut => {
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygenLevel}, Energy: ${astronaut.energyReserves}`);
    })

    function getAstronaut(astronautName) {
        for (let i = 0; i < astronauts.length; i++) {
            if (astronauts[i].name === astronautName) {
                return astronauts[i];
            }

        }
    }
}

solve([    '4',
'Alice 60 100',
'Bob 40 80',
'Charlie 70 150',
'Dave 80 180',
'Explore - Bob - 60',
'Refuel - Alice - 30',
'Breathe - Charlie - 50',
'Refuel - Dave - 40',
'Explore - Bob - 40',
'Breathe - Charlie - 30',
'Explore - Alice - 40',
'End']

);