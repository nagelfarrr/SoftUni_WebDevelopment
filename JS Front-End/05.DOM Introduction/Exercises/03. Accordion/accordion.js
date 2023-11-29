function toggle() {
    let btnContent = document.querySelector("span.button");
    let hiddenDiv = document.getElementById("extra");

    if(btnContent.textContent === "More") {
        hiddenDiv.style.display = "block";
        btnContent.textContent = "Less";
    } else {
        hiddenDiv.style.display = "none";
        btnContent.textContent = "More";
    }

}