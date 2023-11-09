function signCheck(num1, num2, num3) {

    let isNegative = false;

    if(num1 < 0) {
        if( (num2 < 0 && num3 < 0 ) || (num3 < 0 && num2 > 0) || (num3 > 0 && num2 > 0)) {
            isNegative = true;
        }
    } else {
        if ((num2 > 0 && num3 < 0) || (num3 > 0 && num2 < 0)) {
            isNegative = true;
        }
    }

    if(isNegative) {
        console.log("Negative");
    } else {
        console.log("Positive");
    }
}

signCheck(-6, -12, -15)