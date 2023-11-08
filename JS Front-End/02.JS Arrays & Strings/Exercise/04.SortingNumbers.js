function sortNumbers(arr) {
    arr.sort((a, b) => a - b);

    let outputArr = [];

    while(arr.length > 0) {

        outputArr.push(arr.shift());
        outputArr.push(arr.pop());
    }
    
    return outputArr;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);