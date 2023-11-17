function convertObject(jsonString) {

    let person = JSON.parse(jsonString);

    let personEntries = Object.entries(person);

    for (let [personKey, personValue] of personEntries) {
        console.log(`${personKey}: ${personValue}`)
    }

}

convertObject('{"name": "George", "age": 40, "town": "Sofia"}');