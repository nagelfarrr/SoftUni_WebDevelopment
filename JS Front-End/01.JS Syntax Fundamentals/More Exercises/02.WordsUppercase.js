function extractWords(text) {

    const wordsArray = text.split(/\W+/).filter(Boolean);

    let upperCaseArr = [];
    for (let i = 0; i < wordsArray.length; i++) {
        
        upperCaseArr.push(wordsArray[i].toUpperCase());
    }

    console.log(upperCaseArr.join(", "));
}

extractWords("hello");