function formatGrade(grade) {

    let evaluation = "";

    switch (true) {
        case grade < 3.00:
            evaluation = "Fail"
            break;
        case grade < 3.50:
            evaluation = "Poor"
            break;
        case grade < 4.50:
            evaluation = "Good"
            break;
        case grade < 5.50:
            evaluation = "Very good"
            break;
        case grade >= 5.50:
            evaluation = "Excellent"
            break;
    }

    if (evaluation === "Fail") {

        console.log(evaluation + ` (2)`);
    } else {
        console.log(evaluation + ` (${grade.toFixed(2)})`);
    }
}

formatGrade(2.99);