function mathOperations (num1, num2, operator) {
    
    switch (operator) {
        case "+":
            console.log(num1 + num2);
            break;
        case "-":
            console.log(num1 - num2);
        break;
        case "*":
            console.log(num1 * num2);
        break;
        case "/":
            console.log(num1 / num2);
        break;
        case "%":
            console.log(num1 % num2);
        break;
        case "**":
            console.log(num1 ** num2);
        break;
    }
}

mathOperations(5, 2, "**");