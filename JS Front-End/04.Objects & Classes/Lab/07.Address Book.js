function addressBook(inputArr) {

    let addressBook = {};

    for (let index = 0; index < inputArr.length; index++) {

        let tokens = inputArr[index].split(":");
        let name = tokens[0];
        let address = tokens[1];

        addressBook[name] = address;

    }

    const sortedAddressBook = Object.fromEntries(Object.entries(addressBook).sort());

    for (const iterator of Object.entries(sortedAddressBook)) {
        console.log(`${iterator[0]} -> ${iterator[1]}`)
    }
}

addressBook(['Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd']
);