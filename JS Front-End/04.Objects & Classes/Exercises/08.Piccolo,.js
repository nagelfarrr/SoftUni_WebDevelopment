function parkingLot(inputArr) {

    let garage = {};

    for (const element of inputArr) {
        let [direction, carNumber] = element.split(", ");

        if (direction === "IN") {
            garage[carNumber] = carNumber;

        } else {
            garage[carNumber] = null;
        }
    }

    if (Object.values(garage).every(value => value === null)) {
        console.log(`Parking Lot is Empty`)
        return;
    }

    const sortedGarage = Object.keys(garage).sort();

    for (const carNumber of sortedGarage) {
        if (garage[carNumber] !== null) {
            console.log(carNumber);
        }
    }
}

parkingLot(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']


);