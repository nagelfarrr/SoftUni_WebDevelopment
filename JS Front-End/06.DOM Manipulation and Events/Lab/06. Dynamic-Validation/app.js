function validate() {
    const inputField = document.getElementById("email");

    inputField.addEventListener("change", validateEmail);


    function validateEmail() {
        const emailValue = inputField.value.toLowerCase();
        const emailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        const isValidEmail = emailRegex.test(emailValue);

        if (!isValidEmail) {
            inputField.classList.add("error");
        } else {
            inputField.classList.remove("error");
        }
    }

}