function wordsTracker(inputArr) {

    let wordsToTrack = inputArr.shift().split(" ");

    let words = {};

    for (let index = 0; index < wordsToTrack.length; index++) {
        let wordCount = 0

        for (let word = 0; word < inputArr.length; word++) {
            
            words[wordsToTrack[index]] = wordCount;
            if (wordsToTrack[index] === inputArr[word]) {
                wordCount++;

                words[wordsToTrack[index]] = wordCount;

            }
            

        }
    }


    let sortedWords = Object.entries(Object.fromEntries(Object.entries(words).sort(([,a],[,b]) => b-a)));

    for (const iterator of sortedWords) {
        console.log(`${iterator[0]} - ${iterator[1]}`)
    }

}


wordsTracker([
    'is the',
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']

);