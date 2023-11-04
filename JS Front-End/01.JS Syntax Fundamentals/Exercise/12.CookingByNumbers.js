function cookingByNumbers(num, op1, op2, op3, op4, op5) {

    let number = parseInt(num);

    const operations = [
        op1,
        op2,
        op3,
        op4,
        op5,
    ];

    operations.forEach(el => {

        if (el === "chop") {
            num = num / 2;
        } else if(el === "dice") {
            num = Math.sqrt(num);
        } else if(el === "spice") {
            num++;
        } else if (el === "bake") {
            num = num * 3;
        } else if (el === "fillet") {
            num = num - (num * 20/100);
        }
        console.log(num);
    });

}

cookingByNumbers("9", "dice", "spice", "chop", "bake", "fillet");