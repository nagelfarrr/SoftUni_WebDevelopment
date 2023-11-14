function simpleCalculator(num1, operator, num2) {

    switch (operator) {
        case "+":
            console.log((num1 + num2).toFixed(2));
            break;
        case "-":
            console.log((num1 - num2).toFixed(2));
            break;
        case "/":
            console.log((num1 / num2).toFixed(2));
            break;
        case "*":
            console.log((num1 * num2).toFixed(2));
            break;
    }
}

simpleCalculator(0, "/", 2)