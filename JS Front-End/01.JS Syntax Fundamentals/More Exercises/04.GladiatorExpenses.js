function gladiatorExpenses(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {

    let totalExpenses = 0;

    let shieldBrokenTimes = 0;


    for (let fightNumber = 1; fightNumber <= lostFights; fightNumber++) {
        let isHelmetBroken = false;
        let isSwordBroken = false;
        let isSwordAndHelmetBroken = false;
        let isArmorBroken = false;


        if (fightNumber % 2 === 0) {
            isHelmetBroken = true;
        }
        if (fightNumber % 3 === 0) {
            isSwordBroken = true;
        }

        if (isHelmetBroken && isSwordBroken) {
            isSwordAndHelmetBroken = true;
            shieldBrokenTimes++;
        }
        if (shieldBrokenTimes % 2 === 0 && shieldBrokenTimes !== 0) {
            isArmorBroken = true;
            shieldBrokenTimes = 0;
        }

        if (isHelmetBroken) {
            totalExpenses += helmetPrice;
        }
        if (isSwordBroken) {
            totalExpenses += swordPrice;
        }
        if (isSwordAndHelmetBroken) {
            totalExpenses += shieldPrice;
        }
        if (isArmorBroken) {
            totalExpenses += armorPrice;
        }
    }

    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}

gladiatorExpenses(23, 12.50, 21.50, 40, 200);