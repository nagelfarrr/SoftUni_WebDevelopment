function extractSpices(startingYield) {

    let dayCount = 0;
    let totalAmountOfSpices = 0;

    if(startingYield < 100) {
        console.log(`${dayCount}\n${totalAmountOfSpices}`)
    } else {
        while (startingYield >= 100) {
            
            dayCount++;
            totalAmountOfSpices += startingYield - 26;
            startingYield -= 10;
        }
        totalAmountOfSpices -= 26;
        console.log(`${dayCount}\n${totalAmountOfSpices}`)
    }
}

extractSpices(450);