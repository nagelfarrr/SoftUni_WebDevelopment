function sameDigits(num) {
    let sum = 0;
    let digit = num % 10;
    let isDigitsSame = true;

    while (num !== 0) {
        let currentDigit = num % 10;
        sum += currentDigit;
        num = Math.floor(num/10);


        if(digit !== currentDigit) {
            isDigitsSame = false;
            
        } else {
            isDigitsSame = true;
        }
    }

    console.log(isDigitsSame);
    console.log(sum)
}

sameDigits(2222222);