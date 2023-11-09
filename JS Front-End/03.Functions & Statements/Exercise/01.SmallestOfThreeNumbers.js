function getSmallestNumber(num1, num2, num3) {

    let numArr = [num1, num2, num3];
    let sortedArr = numArr.sort((a, b) => a - b);

    console.log(sortedArr[0]);
}

getSmallestNumber(2,2,2);