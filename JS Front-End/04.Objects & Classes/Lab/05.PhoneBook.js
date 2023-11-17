function getPhoneNumber(stringArr) {


    let phoneBook = {};

    for (let line of stringArr) {
        let personInfo = line.split(" ");

        let personName = personInfo[0];
        let personNumber = personInfo[1];

        phoneBook
        [personName] = personNumber;

    }
    for (let key in phoneBook
    ) {
        console.log(`${key} -> ${phoneBook
        [key]}`)
    }
}

getPhoneNumber(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);