function sumDifference(inputArr) {

    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < inputArr.length; i++) {
        
        if(inputArr[i] % 2 === 0) {
            evenSum += inputArr[i];
        } else {
            oddSum += inputArr[i];
        }
    }

    let difference = evenSum - oddSum;

    console.log(difference);
}

sumDifference([2,4,6,8,10]);