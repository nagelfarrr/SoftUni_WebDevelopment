function getCity(cityObj) {

    let cityEntries = Object.entries(cityObj);

    for (let [key, value] of cityEntries) {
        console.log(`${key} -> ${value}`)
    }

}

getCity({ name: "Sofia", area: 492, population: 1238438, country: "Bulgaria", postCode: "1000"});