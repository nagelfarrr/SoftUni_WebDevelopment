function calculateBitcoins(days) {

    let bitcoinPrice = 11949.16;
    let goldPrice = 67.51;

    let bitcoins = 0;
    let leva = 0;
    let firstBitcoinDay = 0;

    for (let i = 1; i <= days.length; i++) {

        let currentGold = days[i - 1];

        if (i % 3 === 0) {
            currentGold = currentGold - 30 * currentGold / 100;
        }

        leva += currentGold * goldPrice;

        if (leva >= bitcoinPrice) {

            while (leva >= bitcoinPrice) {
                leva -= bitcoinPrice;
                bitcoins++;
                if (bitcoins === 1) {
                    firstBitcoinDay = i;
                }
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoins}`);
    if (bitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }
    console.log(`Left money: ${leva.toFixed(2)} lv.`)
}

calculateBitcoins([3124.15, 504.212, 2511.124]);