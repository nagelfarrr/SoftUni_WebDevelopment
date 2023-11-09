function repeatString(string, repeatCount) {

    let result = "";

    for(let i = 0; i < repeatCount; i++) {
        result += string;
    }

    return result;
}

repeatString("String", 2);