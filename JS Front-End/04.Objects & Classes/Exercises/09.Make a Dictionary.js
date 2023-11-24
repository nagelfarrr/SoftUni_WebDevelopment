function dictionary(inputArr) {

    let dictionaryObj = {};
    for (let i = 0; i < inputArr.length; i++) {
        let obj = JSON.parse(inputArr[i]);

        let entries = Object.entries(obj).sort();

        for (let [term, definition] of entries) {
            dictionaryObj[term] = {
                term,
                definition
            }
        }

    }

    let sortedDictionary = Object.keys(dictionaryObj).sort();
    
    for (const word of sortedDictionary) {
        console.log(`Term: ${word} => Definition: ${dictionaryObj[word].definition}`);
    }

}
dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]
);