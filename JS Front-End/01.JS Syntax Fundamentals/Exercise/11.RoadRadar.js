function speedLimit(speed, area) {

    const motorway = 130;
    const interstate = 90;
    const city = 50;
    const residential = 20;

    let speedLimit;

    switch (area) {
        case "motorway":
            speedLimit = motorway;
            break;
        case "interstate":
            speedLimit = interstate;
            break;
        case "city":
            speedLimit = city;
            break;
        case "residential":
            speedLimit = residential;
            break;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`)
    } else {
        let speedDifference = speed - speedLimit;
        let status;

        if (speedDifference <= 20) {
            status = "speeding"
        } else if (speedDifference <= 40) {
            status = "excessive speeding";
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

speedLimit(120, "interstate");