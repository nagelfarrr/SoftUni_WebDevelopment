function focused() {
    let inputElements = Array.from(document.querySelectorAll("input"));
    
    inputElements.forEach(element => {
        element.addEventListener("focus", handleFocus);
        element.addEventListener("blur", handleBlur);
    });

    function handleFocus(e) {
        this.parentNode.classList = "focused";
       
    }
    function handleBlur(e) {
        this.parentNode.classList = "";
    }
}