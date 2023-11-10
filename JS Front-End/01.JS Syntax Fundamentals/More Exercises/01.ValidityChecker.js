function validityChecker(x1, y1, x2, y2) {

    const distanceOriginToP1 = calculateDistance(0, 0, x1, y1);
    const distanceOriginToP2 = calculateDistance(0, 0, x2, y2);
    const distanceP1ToP2 = calculateDistance(x1, y1, x2, y2);

    if (Number.isInteger(distanceOriginToP1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distanceOriginToP2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distanceP1ToP2)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }


    function calculateDistance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2))
    }
}

validityChecker(2, 1, 1, 1);