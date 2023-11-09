function printCharactersInRange(char1, char2) {
    const startCode = char1.charCodeAt(0);
    const endCode = char2.charCodeAt(0);

    let result = "";
    if (startCode <= endCode) {
        for (let i = startCode +1; i < endCode; i++) {
            const char = String.fromCharCode(i);
            result += char + ' ';
        }
    } else {
        for (let i = startCode -1; i > endCode; i--) {
            const char = String.fromCharCode(i);
            result += char + ' ';            
        }

        let charArray = result.split("");
        let reversedArray = charArray.reverse();
        result = reversedArray.join("");
    }

    console.log(result);
}

printCharactersInRange('C','#');
