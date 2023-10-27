function theatrePromotions(typeOfDay, personAge) {

    let result;

    if(personAge < 0 || personAge > 122) {
        result = "Error!"
    }

    if (typeOfDay === "Weekday") {

        if (personAge >= 0 && personAge <= 18) {
            result = "12$"
        }
        else if (personAge > 18 && personAge <= 64) {
            result = "18$"
        }
        else if (personAge > 64 && personAge <= 122) {
            result = "12$"
        }
    }
    else if (typeOfDay === "Weekend") {
        if (personAge >= 0 && personAge <= 18) {
            result = "15$"
        }
        else if (personAge > 18 && personAge <= 64) {
            result = "20$"
        }
        else if (personAge > 64 && personAge <= 122) {
            result = "15$"
        }
    }
    else {
        if (personAge >= 0 && personAge <= 18) {
            result = "5$"
        }
        else if (personAge > 18 && personAge <= 64) {
            result = "12$"
        }
        else if (personAge > 64 && personAge <= 122) {
            result = "10$"
        }
    }

    console.log(result)
}

theatrePromotions("Holiday", 15)