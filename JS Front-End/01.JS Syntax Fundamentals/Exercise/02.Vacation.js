function vacationPrice (numberOfPeople, groupType, day) {

    let finalPrice;

    let pricePerPerson;

    if (groupType === "Students") {
            if (day === "Friday") {
                pricePerPerson = 8.45;
            } else if (day === "Saturday") {
                pricePerPerson = 9.80;
            } else if (day === "Sunday") {
                pricePerPerson = 10.46;
            }
        } else if(groupType === "Business") {
            if (day === "Friday") {
                pricePerPerson = 10.90;
            } else if (day === "Saturday") {
                pricePerPerson = 15.60;
            } else if (day === "Sunday") {
                pricePerPerson = 16.00;
            }
        } else if(groupType === "Regular") {
            if (day === "Friday") {
                pricePerPerson = 15.00;
            } else if (day === "Saturday") {
                pricePerPerson = 20.00;
            } else if (day === "Sunday") {
                pricePerPerson = 22.50;
            }
        }
    

    let priceWithoutDiscount = pricePerPerson * numberOfPeople;

    if (groupType === "Students" && numberOfPeople >= 30) {
        finalPrice = priceWithoutDiscount - (priceWithoutDiscount  * 15/100);
    } else if ( groupType === "Business" && numberOfPeople >= 100) {
        numberOfPeople = numberOfPeople - 10;
        finalPrice = pricePerPerson * numberOfPeople;
    } else if (groupType === "Regular" && (numberOfPeople >= 10 && numberOfPeople <= 20)) {
        finalPrice = priceWithoutDiscount - (priceWithoutDiscount * 5/100);
    } else {
        finalPrice = priceWithoutDiscount;
    }

    console.log(`Total price: ${finalPrice.toFixed(2)}`);

}

vacationPrice(40, "Regular" , "Saturday")