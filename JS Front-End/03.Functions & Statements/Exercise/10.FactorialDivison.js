function factorialDivison(num1, num2) {

    let firstNum = Factorial(num1);
    let secondNum = Factorial(num2);

    console.log((firstNum / secondNum).toFixed(2));

    function Factorial(num) {
        let sum = 1;
        for (let i = 1; i <= num; i++) {
            sum *= i;
        }

        return sum;
    }

}

factorialDivison(6, 2);