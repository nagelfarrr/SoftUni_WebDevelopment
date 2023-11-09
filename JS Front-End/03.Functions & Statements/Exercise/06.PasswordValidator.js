function passwordValidator(password) {

    let isEnoughLength = password.length >= 6 && password.length <= 10
    if (!isEnoughLength) {
        console.log("Password must be between 6 and 10 characters");
    }

    let isOnlytLetterAndDigits = /^[a-zA-z0-9]+$/.test(password)

    if (!isOnlytLetterAndDigits) {
        console.log("Password must consist only of letters and digits");
    }

    let digitCount = 0;

    let hasTwoDigits = false;
    for (let char of password) {
        if (/\d/.test(char)) {
            digitCount++;

            if (digitCount === 2) {
                hasTwoDigits = true;
                break;
            }
        }
    }
    if (!hasTwoDigits) {
        console.log("Password must have at least 2 digits")
    }

    if( isEnoughLength && isOnlytLetterAndDigits && hasTwoDigits) {
        console.log("Password is valid")
    }
}

passwordValidator("444444");