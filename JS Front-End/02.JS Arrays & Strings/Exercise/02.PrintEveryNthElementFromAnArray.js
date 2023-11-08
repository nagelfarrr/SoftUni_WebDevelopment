function printNthElement(strArr, step) {

    let outputArr = [];

    for (let i = 0; i < strArr.length; i++) {
        
        if(i % step === 0) {
            outputArr.push(strArr[i]);
        }
        
    }

    return outputArr;
}

printNthElement(['1', '2','3', '4', '5'], 6);