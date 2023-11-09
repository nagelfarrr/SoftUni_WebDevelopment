function mathPower(num, power) {

    let result = 1;
    for(let i = 0; i < power; i++) {
        result *= num;
    }

    console.log(result);
}

mathPower(3, 4);