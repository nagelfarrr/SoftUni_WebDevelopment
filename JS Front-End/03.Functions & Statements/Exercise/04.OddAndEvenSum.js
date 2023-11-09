function oddAndEvenSum(number) {

    let arr = getDigitArray(number);

    let evenSum = 0;
    let oddSum = 0;
    for (let i = 0; i < arr.length; i++) {

        if (arr[i] % 2 === 0) {
            evenSum += arr[i];
        } else {
            oddSum += arr[i];
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`)

    function getDigitArray(num) {
        let digitArray = [];
        while (num > 0) {
            let digit = num % 10;
            digitArray.unshift(digit);

            num = Math.floor(num / 10);
        }
        return digitArray;
    }
}

oddAndEvenSum(3495892137259234);