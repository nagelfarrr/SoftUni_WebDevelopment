function getTownCoordinates(inputArr) {

    let townCoordinates = {};

    for (let index = 0; index < inputArr.length; index++) {
     
        let townInfo = inputArr[index].split(" | ");
        let townName = townInfo[0];
        let townLatitude = townInfo[1];
        let townLongitude = townInfo[2];

        townCoordinates.town = townName;
        townCoordinates.latitude = Number.parseFloat(townLatitude).toFixed(2);
        townCoordinates.longitude = Number.parseFloat(townLongitude).toFixed(2);

        console.log(townCoordinates);
    }
}

getTownCoordinates(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
);