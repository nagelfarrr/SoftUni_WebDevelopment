function getEmployeePersonalNumber(inputArr) {

    let employee = {

    }

    for (let index = 0; index < inputArr.length; index++) {
        employee.Name = inputArr[index];
        employee.PersonalNumber = inputArr[index].length;

        console.log(`Name: ${employee.Name} -- Personal Number: ${employee.PersonalNumber}`);
    }
}

getEmployeePersonalNumber([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );