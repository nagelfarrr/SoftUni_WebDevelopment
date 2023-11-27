function calc() {
    const num1 = Number(document.getElementById('num1').value);
    const num2 = Number(document.getElementById("num2").value);
    const sumElement = document.getElementById("sum");

    sumElement.value = num1 + num2;
}
