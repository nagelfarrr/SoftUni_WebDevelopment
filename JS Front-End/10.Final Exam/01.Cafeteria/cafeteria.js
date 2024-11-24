function solve(input) {
    const numberOfBaristas = input.shift();

    class Barista {
        constructor(name, shift, coffeTypes) {
            this.name = name,
                this.shift = shift,
                this.coffeTypes = coffeTypes
        }
    };

    let baristas = [];

    for (let i = 0; i < numberOfBaristas; i++) {
        let baristaTokens = input.shift().split(" ");
        let baristaName = baristaTokens[0];
        let baristaShift = baristaTokens[1];
        let baristaCoffeTypes = baristaTokens[2];

        let currentBarista = new Barista(baristaName, baristaShift, baristaCoffeTypes);
        baristas.push(currentBarista);
    }


    let commandLine = input.shift();

    while (commandLine !== "Closed") {

        let commandTokens = commandLine.split(" / ");
        let command = commandTokens[0];
        let baristaName = commandTokens[1];


        let baristaToOperate = getBarista(baristas, baristaName);
        let baristaSkills = baristaToOperate.coffeTypes.split(",");
        switch (command) {
            case "Prepare":
                let shift = commandTokens[2];
                let coffeType = commandTokens[3];

                if (baristaToOperate.shift === shift && baristaSkills.includes(coffeType)) {
                    console.log(`${baristaToOperate.name} has prepared a ${coffeType} for you!`)
                } else {
                    console.log(`${baristaToOperate.name} is not available to prepare a ${coffeType}.`)
                }
                break;
            case "Change Shift":
                let newShift = commandTokens[2];

                baristaToOperate.shift = newShift;
                console.log(`${baristaToOperate.name} has updated his shift to: ${baristaToOperate.shift}`)
                break;
            case "Learn":
                let newCoffeType = commandTokens[2];

                if (baristaSkills.includes(newCoffeType)) {
                    console.log(`${baristaToOperate.name} knows how to make ${newCoffeType}.`)
                } else {
                    baristaSkills.push(newCoffeType);
                    baristaToOperate.coffeTypes = baristaSkills.join(",")

                    console.log(`${baristaToOperate.name} has learned a new coffee type: ${newCoffeType}.`)
                }
                break;

            default:
                break;
        }

        commandLine = input.shift();
    }

    for (let i = 0; i < baristas.length; i++) {
        let baristasCoffeTypesNewFormat = baristas[i].coffeTypes.split(",").join(", ");
        baristas[i].coffeTypes = baristasCoffeTypesNewFormat;
        console.log(`Barista: ${baristas[i].name}, Shift: ${baristas[i].shift}, Drinks: ${baristas[i].coffeTypes}`);

    }


    function getBarista(baristas, baristaName) {
        for (let i = 0; i < baristas.length; i++) {
            if (baristas[i].name === baristaName) {
                return baristas[i];
            }

        }
    }
}

solve(['4',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed']

);

