function reverseArray(n, inputArr) {

    let arr = [];

    for (let i = 0; i < n; i++) {
        arr[i] = inputArr[i];
    }

    arr.reverse();
    let output = "";

    for(let i = 0; i < arr.length; i++) {
        output += `${arr[i]} `
    }

    console.log(output);
}

reverseArray(2, [66,43,75,89,47]);