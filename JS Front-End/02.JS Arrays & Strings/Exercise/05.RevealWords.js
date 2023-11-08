function revealWords(words, text) {

    let wordsArr = words.split(", ");
    let textArr = text.split(" ");

    for (let i = 0; i < wordsArr.length; i++) {

        for (let j = 0; j < textArr.length; j++) {

            if (textArr[j].includes("*") && textArr[j].length === wordsArr[i].length) {

                textArr[j] = wordsArr[i];
            }
        }
    }

    const outputText = textArr.join(" ");

    console.log(outputText);
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');